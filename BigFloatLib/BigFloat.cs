using System;
using System.Numerics;

namespace BigFloatLib
{
    public class BigFloat
    {
        /*
         * 事前設定
         */

        //デフォルト精度変数
        static private UInt64 sAccuracy = 100;

        //デフォルト精度設定関数
        public static void SetAccuracy(UInt64 accuracy)
        {
            BigFloat.sAccuracy = accuracy;
        }

        //メイン数値情報
        BigFloatVar mBigFloatVar;
        BigFloatUtility mBigFloatUtility;
        BigFloatBaseOp mBigFloatBaseOp;
        //初期化関数
        public BigFloat()
        {
            mBigFloatVar = new BigFloatVar();
            mBigFloatUtility = new BigFloatUtility();
            mBigFloatBaseOp = new BigFloatBaseOp();
            mBigFloatVar.mAccuracy = sAccuracy;
        }
        //文字列で初期化
        public BigFloat(string initialVar)
        {
            mBigFloatVar = new BigFloatVar();
            mBigFloatUtility = new BigFloatUtility();
            mBigFloatBaseOp = new BigFloatBaseOp();
            mBigFloatVar = mBigFloatUtility.Parse(initialVar, mBigFloatVar);
            mBigFloatVar.mAccuracy = sAccuracy;
        }

        //整数で初期化
        public BigFloat(short initialVar)
        {
            BigFloatInts(initialVar);
        }
        public BigFloat(int initialVar)
        {
            BigFloatInts(initialVar);
        }
        public BigFloat(long initialVar)
        {
            BigFloatInts(initialVar);
        }

        //浮動小数点で初期化
        public BigFloat(float initialVar)
        {
            BigFloatFloats(initialVar);
        }
        public BigFloat(double initialVar)
        {
            BigFloatFloats(initialVar);
        }

        private void BigFloatFloats(double initialVar)
        {
            mBigFloatVar = new BigFloatVar();
            mBigFloatUtility = new BigFloatUtility();
            mBigFloatBaseOp = new BigFloatBaseOp();
            mBigFloatVar = mBigFloatUtility.ConvertFloat(initialVar, mBigFloatVar);
            mBigFloatVar.mAccuracy = sAccuracy;//要検証
        }
        private void BigFloatInts(long initialVar)
        {
            mBigFloatVar = new BigFloatVar();
            mBigFloatUtility = new BigFloatUtility();
            mBigFloatBaseOp = new BigFloatBaseOp();
            mBigFloatVar = mBigFloatUtility.ConvertInt(initialVar, mBigFloatVar);
            mBigFloatVar.mAccuracy = sAccuracy;
        }

        public BigFloat Add (BigFloat initialVar)
        {
            mBigFloatVar = mBigFloatBaseOp.Add(mBigFloatVar,initialVar.mBigFloatVar);
            return this;
        }
    }
}
