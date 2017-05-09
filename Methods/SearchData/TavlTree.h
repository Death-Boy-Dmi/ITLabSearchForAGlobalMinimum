#include <iostream>
using namespace std;

typedef struct TNode *nodeptr;

//
//struct TTask
//{
//	Function func;
//	double xl;
//	double xr;
//	double eps;
//	int maxOfIterations;
//};

struct TPoint
{
	double x; //точка на одномерном отрезке
	double y; //значение функции
};


struct TNode
{
	TPoint element; // ключ узла, является x
	int height; // высота поддерева с корнем в данном узле
	TNode *left;
	TNode *right;
};

//  узлы АВЛ-дерева хранят не высоту, а разницу высот правого и левого поддеревьев (так называемый balance factor)


class TavlTree
{

public:
	void insert(TPoint x, nodeptr &p)
	{
		if (p == NULL)
		{
			p = new TNode;
			p->element.x = x.x;
			p->left = NULL;
			p->right = NULL;
			p->height = 0;
			if (p == NULL)
			{
				//cout << "Out of Space\n" << endl;
			}
		}
		else
		{
			if (x.x<p->element.x)
			{
				insert(x, p->left);
				if ((bsheight(p->left) - bsheight(p->right)) == 2)
				{
					if (x.x < p->left->element.x)
					{
						p = srl(p);
					}
					else
					{
						p = drl(p);
					}
				}
			}
			else if (x.x>p->element.x)
			{
				insert(x, p->right);
				if ((bsheight(p->right) - bsheight(p->left)) == 2)
				{
					if (x.x > p->right->element.x)
					{
						p = srr(p);
					}
					else
					{
						p = drr(p);
					}
				}
			}
			else
			{
				//cout << "Элемет существует\n" << endl;
			}
		}
		int m, n, d;
		m = bsheight(p->left);
		n = bsheight(p->right);
		d = max(m, n);
		p->height = d + 1;
	}

	nodeptr findmin(nodeptr p)
	{
		if (p == NULL)
		{
			//cout << "В дереве нет элементов\n" << endl;
			return p;
		}
		else
		{
			while (p->left != NULL)
			{
				p = p->left;
				//return p;
			}
			return p;
		}
	}

	nodeptr findmax(nodeptr p)
	{
		if (p == NULL)
		{
			//cout << "В дереве нет элементов\n" << endl;
			return p;
		}
		else
		{
			while (p->right != NULL)
			{
				p = p->right;
			}
			return p;
		}
	}

	void find(TPoint x, nodeptr &p)
	{
		if (p == NULL)
		{
			//cout << "Простите, но такого элемента нет\n" << endl;
		}
		else
		{
			if (x.x < p->element.x)
			{
				find(x, p->left);
			}
			else
			{
				if (x.x>p->element.x)
				{
					find(x, p->right);
				}
				else
				{
					//cout << "Элемент, который вы искали есть в дереве!\n" << endl;
				}
			}
		}
	}


	/*void del(int x, nodeptr &p)
	{
		nodeptr d;
		if (p == NULL)
		{
			cout << "Простите, но такого элемента нет\n" << endl;
		}
		else if (x < p->element)
		{
			del(x, p->left);
		}
		else if (x > p->element)
		{
			del(x, p->right);
		}
		else if ((p->left == NULL) && (p->right == NULL))
		{
			d = p;
			free(d);
			p = NULL;
			cout << "Элемент удален\n" << endl;
		}
		else if (p->left == NULL)
		{
			d = p;
			free(d);
			p = p->right;
			cout << "Элемент удален\n" << endl;
		}
		else if (p->right == NULL)
		{
			d = p;
			p = p->left;
			free(d);
			cout << "Элемент удален\n" << endl;
		}
		else
		{
			p->element = deletemin(p->right);
		}
	}*/

	void preorder(nodeptr p)
	{
		if (p != NULL)
		{
			cout << p->element.x << "\t";
			preorder(p->left);
			preorder(p->right);
		}
	}

	void inorder(nodeptr p)
	{
		if (p != NULL)
		{
			inorder(p->left);
			cout << p->element.x << "\t";
			inorder(p->right);
		}
	}


	void postorder(nodeptr p)
	{
		if (p != NULL)
		{
			postorder(p->left);
			postorder(p->right);
			cout << p->element.x << "\t";
		}
	}

	int max(int value1, int value2)
	{
		return ((value1 > value2) ? value1 : value2);
	}
	int bsheight(nodeptr p)
	{
		int t;
		if (p == NULL)
		{
			return -1;
		}
		else
		{
			t = p->height;
			return t;
		}
	}

	nodeptr srl(nodeptr &p1)
	{
		nodeptr p2;
		p2 = p1->left;
		p1->left = p2->right;
		p2->right = p1;
		p1->height = max(bsheight(p1->left), bsheight(p1->right)) + 1;
		p2->height = max(bsheight(p2->left), p1->height) + 1;
		return p2;
	}
	nodeptr srr(nodeptr &p1)
	{
		nodeptr p2;
		p2 = p1->right;
		p1->right = p2->left;
		p2->left = p1;
		p1->height = max(bsheight(p1->left), bsheight(p1->right)) + 1;
		p2->height = max(p1->height, bsheight(p2->right)) + 1;
		return p2;
	}
	nodeptr drl(nodeptr &p1)
	{
		p1->left = srr(p1->left);
		return srl(p1);
	}
	nodeptr drr(nodeptr &p1)
	{
		p1->right = srl(p1->right);
		return srr(p1);
	}

	int nonodes(nodeptr p)
	{
		int count = 0;
		if (p != NULL)
		{
			nonodes(p->left);
			nonodes(p->right);
			count++;
		}
		return count;
	}
};
