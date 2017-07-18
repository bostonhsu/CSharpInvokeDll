// Win32Project1.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include <math.h>

extern "C" __declspec(dllexport) int Add(int x, int y)
{
	return x + y;
}

extern "C" __declspec(dllexport) void Pow(int* x, double y)
{
	*x = pow(*x, y);
}

