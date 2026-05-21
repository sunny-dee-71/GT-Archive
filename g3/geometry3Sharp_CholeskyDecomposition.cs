using System;
using System.Collections.Generic;

namespace g3;

public class CholeskyDecomposition
{
	public DenseMatrix A;

	public DenseMatrix L;

	public CholeskyDecomposition(DenseMatrix m)
	{
		A = m;
	}

	public bool Compute()
	{
		if (A.Rows != A.Columns)
		{
			throw new Exception("CholeskyDecomposition.Compute(): cannot be applied to non-square matrix");
		}
		int rows = A.Rows;
		L = new DenseMatrix(rows, rows);
		double[] buffer = L.Buffer;
		L[0, 0] = Math.Sqrt(A[0, 0]);
		for (int i = 1; i < rows; i++)
		{
			L[i, 0] = A[i, 0] / L[0, 0];
			double num = L[i, 0] * L[i, 0];
			for (int j = 1; j < i; j++)
			{
				double num2 = 0.0;
				int num3 = i * rows;
				int num4 = j * rows;
				int num5 = num4 + j;
				while (num4 < num5)
				{
					num2 += buffer[num3++] * buffer[num4++];
				}
				L[i, j] = 1.0 / L[j, j] * (A[i, j] - num2);
				num += L[i, j] * L[i, j];
			}
			L[i, i] = Math.Sqrt(A[i, i] - num);
		}
		return true;
	}

	public bool ComputeParallel()
	{
		if (A.Rows != A.Columns)
		{
			throw new Exception("CholeskyDecomposition.ComputeParallel(): cannot be applied to non-square matrix");
		}
		int N = A.Rows;
		L = new DenseMatrix(N, N);
		double[] Lbuf = L.Buffer;
		Action<int> compute_diag = delegate(int r)
		{
			double num4 = 0.0;
			int num5 = r * N;
			int num6 = num5 + r;
			do
			{
				num4 += Lbuf[num5] * Lbuf[num5];
			}
			while (num5++ < num6);
			L[r, r] = Math.Sqrt(A[r, r] - num4);
		};
		L[0, 0] = Math.Sqrt(A[0, 0]);
		for (int num = 1; num < N; num++)
		{
			L[num, 0] = A[num, 0] / L[0, 0];
		}
		compute_diag(1);
		int c = 1;
		while (c < N)
		{
			int num2 = N - 1 - (c + 1);
			gParallel.BlockStartEnd(c + 1, N - 1, delegate(int a, int b)
			{
				for (int i = a; i <= b; i++)
				{
					double num4 = 0.0;
					int num5 = i * N;
					int num6 = c * N;
					int num7 = num6 + c;
					while (num6 < num7)
					{
						num4 += Lbuf[num5++] * Lbuf[num6++];
					}
					L[i, c] = 1.0 / L[c, c] * (A[i, c] - num4);
					if (i == c + 1)
					{
						compute_diag(i);
					}
				}
			}, Math.Max(num2 / 20, 1));
			int num3 = c + 1;
			c = num3;
		}
		return true;
	}

	private IEnumerable<Vector2i> diag_itr()
	{
		int N = A.Rows;
		for (int r = 2; r < N; r++)
		{
			Vector2i rj = new Vector2i(r - 1, 1);
			while (rj.y <= rj.x)
			{
				yield return rj;
				rj.x--;
				rj.y++;
			}
		}
		for (int r = 1; r < N; r++)
		{
			Vector2i rj = new Vector2i(N - 1, r);
			while (rj.y <= rj.x)
			{
				yield return rj;
				rj.x--;
				rj.y++;
			}
		}
	}

	public void Solve(double[] B, double[] X, double[] Y)
	{
		int rows = A.Rows;
		if (Y == null)
		{
			Y = new double[rows];
		}
		Y[0] = B[0] / L[0, 0];
		for (int i = 1; i < rows; i++)
		{
			double num = 0.0;
			for (int j = 0; j < i; j++)
			{
				num += L[i, j] * Y[j];
			}
			Y[i] = (B[i] - num) / L[i, i];
		}
		X[rows - 1] = Y[rows - 1] / L[rows - 1, rows - 1];
		for (int num2 = rows - 2; num2 >= 0; num2--)
		{
			double num3 = 0.0;
			for (int k = num2 + 1; k < rows; k++)
			{
				num3 += L[k, num2] * X[k];
			}
			X[num2] = (Y[num2] - num3) / L[num2, num2];
		}
	}
}
