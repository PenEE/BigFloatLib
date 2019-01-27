using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace BigFloatLib
{
    class BigFloatUtility
    {
        //Str=>BigFloat パーズ関数
        //少し長いかも・・・
        public BigFloatVar Parse(string inParseStr, BigFloatVar inBigFloatVar)
        {
            if (Regex.IsMatch(inParseStr, @"^[0-9|e|\.|\-|\+]$"))
            {
                //例外処理
                return null;
            }

            //指数部切り離し
            var tParseStrSpl = inParseStr.Split('e');

            if (tParseStrSpl.Length > 2)
            {
                //例外処理
                return null;
            }
            var tStrFraction = tParseStrSpl[0];

            //小数点の位置を検索し指数に登録
            var tPointSum = Regex.Matches(tStrFraction, @"\.");
            var tDecimalPoint = 0;


            if (tPointSum.Count == 0)
            {
                tDecimalPoint = tStrFraction.Length;
            }
            else if (tPointSum.Count == 1)
            {
                tDecimalPoint = tStrFraction.LastIndexOf(".");
                tStrFraction = tStrFraction.Remove(tDecimalPoint, 1);
            }
            else
            {
                //例外処理
                return null;
            }

            //符号がついていた場合の処理
            var tTopChar = tStrFraction.ToCharArray()[0];
            if (tTopChar == '+' || tTopChar == '-')
            {
                tDecimalPoint--;
            }

            inBigFloatVar.mExponent = tDecimalPoint;

            //BigIntegerでパーズ
            inBigFloatVar.mFraction = BigInteger.Parse(tStrFraction);

            //指数があった場合は算出し指数に加算
            if (tParseStrSpl.Length == 2)
            {
                var tStrExponent = tParseStrSpl[1];

                //指数部算出
                if (tStrExponent.Contains("."))
                {
                    //例外処理
                    return null;
                }

                inBigFloatVar.mExponent += BigInteger.Parse(tStrExponent);
            }

            ExponentDigitFunc(inBigFloatVar);

            return inBigFloatVar;
        }
        //Int=>BigFloat変換
        public BigFloatVar ConvertInt(long inInt, BigFloatVar inBigFloatVar)
        {
            UInt64 digit = 0;
            for (long i = inInt; i != 0; i /= 10)
            {
                digit++;
            }

            inBigFloatVar.mExponent += digit;
            inBigFloatVar.mFractionDigit = digit;
            inBigFloatVar.mFraction += inInt;

            return inBigFloatVar;
        }
        //Float=>BigFloat変換
        public BigFloatVar ConvertFloat(double inDouble, BigFloatVar inBigFloatVar)
        {
            var Times = 10;
            var DoubleTmp = inDouble;
            while (DoubleTmp % 1 != 0)
            {
                inBigFloatVar.mExponent--;
                DoubleTmp = inDouble * Times;
                Times *= 10;
            }
            inBigFloatVar = ConvertInt((long)DoubleTmp, inBigFloatVar);

            return inBigFloatVar;
        }
        public string StrConvert(BigFloatVar inBigFloatVar)
        {
            string res = "";
            return res;
        }

        private BigFloatVar ExponentDigitFunc(BigFloatVar inBigFloatVar)
        {
            inBigFloatVar.mFractionDigit = 0;
            for (BigInteger i = inBigFloatVar.mFraction; i != 0; i /= 10)
            {
                inBigFloatVar.mFractionDigit++;
            }
            return inBigFloatVar;
        }
    }
}
