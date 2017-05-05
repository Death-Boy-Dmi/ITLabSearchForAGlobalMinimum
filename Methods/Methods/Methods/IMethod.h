#include "../../Function/TFunction.h"

struct TPoint
{
	double x;
	double y;
};
struct TTask
{
	std::string str_function;
	double xl;
	double xr;
	double eps;
	int maxOfIterations;
	int r;
};

class IMethod
{
protected:
	/// ������������ ����� ���������
	int MaxNumOfTrials;
	/// �������� ������� ������
	double Epsilon;
	/// ��������� �� �������� ������
	TTask *pTask;
	/// ��������� �� ������� ��������� ������
	/*TSearchData *pData;*/

public:
	IMethod() {	}
	IMethod(int _MaxNumOfTrials, double _Eps, TTask *_pTask/*, TSearchData *_pData*/) {	}
	~IMethod() { }

	//virtual void RenewSearchData() = 0;

	virtual TPoint CalculateOptimum() = 0;
};