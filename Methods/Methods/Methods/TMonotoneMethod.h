#pragma once
#include "IMethod.h"
#include <map>

typedef map<double, double> mapP;

class TMonotoneMethod : public IMethod
{
protected:
	TFunction function;
	double maxZ, minZ, minX, m;

	double Transform(mapP::iterator pair)
	{
		return sqrt(1 - pow(((maxZ - pair->second) / (maxZ - minZ)), 2));
	}

public:
	TMonotoneMethod(TTask *_pTask, TSearchData *_pData)
	{
		pTask = _pTask;
		pData = _pData;	
		TFunction _func(pTask->str_function);
		function = _func;
	}

	virtual void RenewSearchData(double _x)
	{
		double _y = Function(_x);
		TPoint tmp;
		tmp.x = _x; tmp.y = _y;
		pData->insert(tmp, root);
	}

	double Function(double x)
	{
		return function.Calculate(x);
	}

	mapP::iterator Ñharacteristic(mapP& p, double m)
	{
		mapP::iterator interval;
		double res, tmp;
		for (mapP::iterator itPL = p.begin(), itPR = ++p.begin(); itPR != p.end(); ++itPL, ++itPR)
		{
			if (itPL == p.begin())
			{
				res = m * (itPR->first - itPL->first) + (pow(Transform(itPR) - Transform(itPL), 2) / (m * (itPR->first - itPL->first)) - 2 * (Transform(itPR) - Transform(itPL)));
				interval = itPL;
			}
			else
			{
				tmp = m * (itPR->first - itPL->first) + (pow(Transform(itPR) - Transform(itPL), 2) / (m * (itPR->first - itPL->first)) - 2 * (Transform(itPR) - Transform(itPL)));
				if (res < tmp)
				{
					res = tmp;
					interval = itPL;
				}
			}
		}
		return interval;
	}

	double GetM(mapP::iterator pair1, mapP::iterator pair2, double last)
	{
		double result, tmp;

		tmp = abs(Transform(pair2) - Transform(pair1)) / (pair2->first - pair1->first);

		if (tmp == 0)
			result = 1;
		else if (tmp > last)
			result = pTask->r * tmp;
		else
			result = last;

		return result;
	}

	double SetPoint(mapP::iterator pair1, mapP::iterator pair2, double m)
	{
		double result;

		result = 0.5 * (pair1->first + pair2->first) - 0.5 * (Transform(pair2) - Transform(pair1)) / m;

		return result;
	}

	bool Distance(mapP::iterator pair1, mapP::iterator pair2)
	{
		return abs(pair1->first - pair2->first) <= pTask->eps;
	}

	virtual TPoint CalculateOptimum()
	{
		mapP Points;
		TPoint result;
		double B = pTask->xr;
		double A = pTask->xl;
		double m, tmpX, tmpY;
		int pair = 1;
		Points.insert(make_pair(A, Function(A)));
		Points.insert(make_pair(B, Function(B)));

		if (Function(A) < Function(B))
		{
			minZ = Function(A);
			maxZ = Function(B);
			minX = A;
		}
		else
		{
			minZ = Function(B);
			maxZ = Function(A);
			minX = B;
		}

		mapP::iterator itP = Points.begin();
		mapP::iterator itP1 = ++Points.begin();
		m = GetM(itP, itP1, -1);

		for (int i = 2; i < pTask->maxOfIterations; ++i)
		{
			mapP::iterator tmp = Ñharacteristic(Points, m);
			mapP::iterator tmp2 = tmp;
			++tmp2;

			tmpX = SetPoint(tmp, tmp2, m);
			tmpY = Function(tmpX);
			RenewSearchData(tmpX);

			if (tmpY > maxZ) maxZ = tmpY;
			if (tmpY < minZ)
			{
				minZ = tmpY;
				minX = tmpX;
			}

			Points.insert(make_pair(tmpX, tmpY));

			tmp = Points.find(tmpX);
			tmp2 = --Points.find(tmpX);

			if (Distance(tmp, tmp2))
				break;
			m = GetM(tmp2, tmp, m);

			tmp = Points.find(tmpX);
			tmp2 = ++Points.find(tmpX);

			if (Distance(tmp, tmp2))
				break;
			m = GetM(tmp, tmp2, m);
		}

		result.x = minX;
		result.y = minZ;
		return result;
	}
};