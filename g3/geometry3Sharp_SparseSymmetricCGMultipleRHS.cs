using System;

namespace g3;

public class SparseSymmetricCGMultipleRHS
{
	public Action<double[][], double[][]> MultiplyF;

	public Action<double[][], double[][]> PreconditionMultiplyF;

	public double[][] B;

	public double ConvergeTolerance = 1E-08;

	public double[][] X;

	public bool UseXAsInitialGuess = true;

	public int MaxIterations = 1024;

	public int Iterations;

	private double[][] R;

	private double[][] P;

	private double[][] W;

	private double[][] AP;

	private double[][] Z;

	public bool Solve()
	{
		Iterations = 0;
		if (B == null || MultiplyF == null)
		{
			throw new Exception("SparseSymmetricCGMultipleRHS.Solve(): Must set B and MultiplyF!");
		}
		int num = B.Length;
		if (num == 0)
		{
			throw new Exception("SparseSymmetricCGMultipleRHS.Solve(): Need at least one RHS vector in B");
		}
		int num2 = B[0].Length;
		R = BufferUtil.AllocNxM(num, num2);
		P = BufferUtil.AllocNxM(num, num2);
		W = BufferUtil.AllocNxM(num, num2);
		if (X == null || !UseXAsInitialGuess)
		{
			if (X == null)
			{
				X = BufferUtil.AllocNxM(num, num2);
			}
			for (int i = 0; i < num; i++)
			{
				Array.Clear(X[i], 0, num2);
				Array.Copy(B[i], R[i], num2);
			}
		}
		else
		{
			InitializeR(R);
		}
		double[] array = new double[num];
		for (int j = 0; j < num; j++)
		{
			array[j] = BufferUtil.Dot(B[j], B[j]);
		}
		double[] array2 = new double[num];
		for (int k = 0; k < num; k++)
		{
			array2[k] = Math.Sqrt(array[k]);
		}
		double[] rho0 = new double[num];
		for (int l = 0; l < num; l++)
		{
			rho0[l] = BufferUtil.Dot(R[l], R[l]);
		}
		bool[] converged = new bool[num];
		int num3 = 0;
		for (int m = 0; m < num; m++)
		{
			converged[m] = rho0[m] < ConvergeTolerance * array2[m];
			if (converged[m])
			{
				num3++;
			}
		}
		if (num3 == num)
		{
			return true;
		}
		for (int n = 0; n < num; n++)
		{
			Array.Copy(R[n], P[n], num2);
		}
		MultiplyF(P, W);
		double[] alpha = new double[num];
		for (int num4 = 0; num4 < num; num4++)
		{
			alpha[num4] = rho0[num4] / BufferUtil.Dot(P[num4], W[num4]);
		}
		for (int num5 = 0; num5 < num; num5++)
		{
			BufferUtil.MultiplyAdd(X[num5], alpha[num5], P[num5]);
		}
		for (int num6 = 0; num6 < num; num6++)
		{
			BufferUtil.MultiplyAdd(R[num6], 0.0 - alpha[num6], W[num6]);
		}
		double[] rho1 = new double[num];
		for (int num7 = 0; num7 < num; num7++)
		{
			rho1[num7] = BufferUtil.Dot(R[num7], R[num7]);
		}
		double[] array3 = new double[num];
		Interval1i interval1i = Interval1i.Range(num);
		int num8;
		for (num8 = 1; num8 < MaxIterations; num8++)
		{
			bool flag = true;
			for (int num9 = 0; num9 < num; num9++)
			{
				if (!converged[num9] && Math.Sqrt(rho1[num9]) <= ConvergeTolerance * array2[num9])
				{
					converged[num9] = true;
				}
				if (!converged[num9])
				{
					flag = false;
				}
			}
			if (flag)
			{
				break;
			}
			for (int num10 = 0; num10 < num; num10++)
			{
				array3[num10] = rho1[num10] / rho0[num10];
			}
			UpdateP(P, array3, R, converged);
			MultiplyF(P, W);
			gParallel.ForEach(interval1i, delegate(int num11)
			{
				if (!converged[num11])
				{
					alpha[num11] = rho1[num11] / BufferUtil.Dot(P[num11], W[num11]);
				}
			});
			gParallel.ForEach(interval1i, delegate(int num11)
			{
				if (!converged[num11])
				{
					BufferUtil.MultiplyAdd(X[num11], alpha[num11], P[num11]);
				}
			});
			gParallel.ForEach(interval1i, delegate(int num11)
			{
				if (!converged[num11])
				{
					rho0[num11] = rho1[num11];
					rho1[num11] = BufferUtil.MultiplyAdd_GetSqrSum(R[num11], 0.0 - alpha[num11], W[num11]);
				}
			});
		}
		Iterations = num8;
		return num8 < MaxIterations;
	}

	public bool SolvePreconditioned()
	{
		Iterations = 0;
		if (B == null || MultiplyF == null || PreconditionMultiplyF == null)
		{
			throw new Exception("SparseSymmetricCGMultipleRHS.SolvePreconditioned(): Must set B and MultiplyF and PreconditionMultiplyF!");
		}
		int num = B.Length;
		if (num == 0)
		{
			throw new Exception("SparseSymmetricCGMultipleRHS.SolvePreconditioned(): Need at least one RHS vector in B");
		}
		int n = B[0].Length;
		R = BufferUtil.AllocNxM(num, n);
		P = BufferUtil.AllocNxM(num, n);
		AP = BufferUtil.AllocNxM(num, n);
		Z = BufferUtil.AllocNxM(num, n);
		if (X == null || !UseXAsInitialGuess)
		{
			if (X == null)
			{
				X = BufferUtil.AllocNxM(num, n);
			}
			for (int i = 0; i < num; i++)
			{
				Array.Clear(X[i], 0, n);
				Array.Copy(B[i], R[i], n);
			}
		}
		else
		{
			InitializeR(R);
		}
		double[] array = new double[num];
		for (int j = 0; j < num; j++)
		{
			array[j] = BufferUtil.Dot(B[j], B[j]);
		}
		double[] array2 = new double[num];
		for (int k = 0; k < num; k++)
		{
			array2[k] = Math.Sqrt(array[k]);
		}
		MultiplyF(X, R);
		for (int l = 0; l < num; l++)
		{
			for (int m = 0; m < n; m++)
			{
				R[l][m] = B[l][m] - R[l][m];
			}
		}
		PreconditionMultiplyF(R, Z);
		for (int num2 = 0; num2 < num; num2++)
		{
			Array.Copy(Z[num2], P[num2], n);
		}
		double[] RdotZ_k = new double[num];
		for (int num3 = 0; num3 < num; num3++)
		{
			RdotZ_k[num3] = BufferUtil.Dot(R[num3], Z[num3]);
		}
		double[] alpha_k = new double[num];
		double[] beta_k = new double[num];
		bool[] converged = new bool[num];
		Interval1i interval1i = Interval1i.Range(num);
		int num4 = 0;
		while (num4++ < MaxIterations)
		{
			bool flag = true;
			for (int num5 = 0; num5 < num; num5++)
			{
				if (!converged[num5] && Math.Sqrt(RdotZ_k[num5]) <= ConvergeTolerance * array2[num5])
				{
					converged[num5] = true;
				}
				if (!converged[num5])
				{
					flag = false;
				}
			}
			if (flag)
			{
				break;
			}
			MultiplyF(P, AP);
			gParallel.ForEach(interval1i, delegate(int num6)
			{
				if (!converged[num6])
				{
					alpha_k[num6] = RdotZ_k[num6] / BufferUtil.Dot(P[num6], AP[num6]);
				}
			});
			gParallel.ForEach(interval1i, delegate(int num6)
			{
				if (!converged[num6])
				{
					BufferUtil.MultiplyAdd(X[num6], alpha_k[num6], P[num6]);
				}
			});
			gParallel.ForEach(interval1i, delegate(int num6)
			{
				if (!converged[num6])
				{
					BufferUtil.MultiplyAdd(R[num6], 0.0 - alpha_k[num6], AP[num6]);
				}
			});
			PreconditionMultiplyF(R, Z);
			gParallel.ForEach(interval1i, delegate(int num6)
			{
				if (!converged[num6])
				{
					beta_k[num6] = BufferUtil.Dot(Z[num6], R[num6]) / RdotZ_k[num6];
				}
			});
			gParallel.ForEach(interval1i, delegate(int num6)
			{
				if (!converged[num6])
				{
					for (int num7 = 0; num7 < n; num7++)
					{
						P[num6][num7] = Z[num6][num7] + beta_k[num6] * P[num6][num7];
					}
				}
			});
			gParallel.ForEach(interval1i, delegate(int num6)
			{
				if (!converged[num6])
				{
					RdotZ_k[num6] = BufferUtil.Dot(R[num6], Z[num6]);
				}
			});
		}
		Iterations = num4;
		return num4 < MaxIterations;
	}

	private void UpdateP(double[][] P, double[] beta, double[][] R, bool[] converged)
	{
		gParallel.ForEach(Interval1i.Range(P.Length), delegate(int j)
		{
			if (!converged[j])
			{
				int num = P[j].Length;
				for (int i = 0; i < num; i++)
				{
					P[j][i] = R[j][i] + beta[j] * P[j][i];
				}
			}
		});
	}

	private void InitializeR(double[][] R)
	{
		MultiplyF(X, R);
		for (int i = 0; i < X.Length; i++)
		{
			int num = R[i].Length;
			for (int j = 0; j < num; j++)
			{
				R[i][j] = B[i][j] - R[i][j];
			}
		}
	}
}
