using System;
using System.Numerics;

namespace BigFloatLib
{
    class BigFloatBaseOp
    {
        public BigFloatVar Add(BigFloatVar myBigFloatVar, BigFloatVar inBigFloatVar)
        {
            var myBase = myBigFloatVar.mExponent - myBigFloatVar.mFractionDigit;
            var inBase = inBigFloatVar.mExponent - inBigFloatVar.mFractionDigit;

            if (myBase >= inBase)
            {
                var tDiff = myBase - inBase;
                myBigFloatVar.mFraction *= BigIntegerPow(10, tDiff);

                myBigFloatVar.mFraction += inBigFloatVar.mFraction;

                myBigFloatVar.mFractionDigit += (UInt64)tDiff;
            }
            if (myBase < inBase)
            {
                var tDiff = inBase - myBase;
                inBigFloatVar.mFraction *= BigIntegerPow(10, tDiff);

                myBigFloatVar.mFraction += inBigFloatVar.mFraction;

                myBigFloatVar.mFractionDigit += (UInt64)tDiff;
            }

            myBigFloatVar.mExponent = inBigFloatVar.mExponent;

            return myBigFloatVar;
        }

        //	高速らしい版	for版
        private BigInteger BigIntegerPow(BigInteger _x, BigInteger _n)
        {
            BigInteger ret = 1;
            while (0 < _n)
            {
                if ((_n % 2) == 0)
                {
                    _x *= _x;
                    _n >>= 1;
                }
                else
                {
                    ret *= _x;
                    --_n;
                }
            }
            return ret;
        }
    }
}
