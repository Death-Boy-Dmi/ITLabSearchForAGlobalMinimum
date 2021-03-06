#include "../AllMethods.h"

using namespace std;

void main()
{
	TTask task;
	//
	TPoint optimumD;
	TSearchData pDataD;
	///
	TPoint optimumM;
	TSearchData pDataM;
	///
	TPoint optimumN;
	TSearchData pDataN;
	///
	TPoint optimumS;
	TSearchData pDataS;
	///
	task.str_function = "(x/4)*cos(x)";
	task.xl = 0;
	task.xr = 30;
	task.maxOfIterations = 100;
	task.eps = 0.001;
	int r = 7;
	///
	TMethodOfGlobalSearch MoGS(&task, r, &pDataD);
	optimumD = MoGS.CalculateOptimum();
	cout << "(" << optimumD.x << ", " << optimumD.y << ")" << endl;

	TMonotoneMethod MMoGS(&task, r, &pDataM);
	optimumM = MMoGS.CalculateOptimum();
	cout << "(" << optimumM.x << ", " << optimumM.y << ")" << endl;

	double M = 0.5;
	TMethodOfPiyavsky MoP(&task, M, &pDataN);
	optimumN = MoP.CalculateOptimum();
	cout << "(" << optimumN.x << ", " << optimumN.y << ")" << endl;

	double Y = 0.5;
	TMethodOfKushner MoK(&task, Y, &pDataS);
	optimumS = MoK.CalculateOptimum();
	cout << "(" << optimumS.x << ", " << optimumS.y << ")" << endl;
}