#include "TMethodOfGlobalSearch.h"
//#include "TMonotoneMethod.h"
//#include "TMethodOfPiyavsky.h"
//#include "TMethodOfKushner.h"

void main()
{
	TTask task;
	//
	TPoint optimumD;
	TSearchData pDataD;
	//
	TPoint optimumM;
	TSearchData pDataM;
	//
	TPoint optimumN;
	TSearchData pDataN;
	//
	TPoint optimumS;
	TSearchData pDataS;
	///
	task.str_function = "(x/4)*cos(x)";
	task.xl = 0;
	task.xr = 30;
	task.maxOfIterations = 100000;
	task.eps = 0.00001;
	task.r = 3;
	///
	TMethodOfGlobalSearch MoGS(&task,&pDataD);
	optimumD = MoGS.CalculateOptimum();
	cout << "(" << optimumD.x << ", " << optimumD.y << ")" << endl;

	//TMonotoneMethod MMoGS(&task, &pDataM);
	//optimumM = MMoGS.CalculateOptimum();
	//cout << "(" << optimumM.x << ", " << optimumM.y << ")" << endl;

	//double M = 3;
	//TMethodOfPiyavsky MoP(&task, M, &pDataM);
	//optimumN = MoP.CalculateOptimum();
	//cout << "(" << optimumN.x << ", " << optimumN.y << ")" << endl;

	//TMethodOfKushner MoK(&task, &pDataM);
	//optimumS = MMoGS.CalculateOptimum();
	//cout << "(" << optimumS.x << ", " << optimumS.y << ")" << endl;

}