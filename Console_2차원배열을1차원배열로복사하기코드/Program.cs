using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_2차원배열을1차원배열로복사하기코드
{
    public class ArraytoCopy
    {
        private UInt16[,] volts;

        public ArraytoCopy(UInt16[,] data)
        {
            volts = data;
        }

        //while문으로 구현
        public UInt16[] CopyTo1DArray(int[] serialCounts)
        {
            if (serialCounts == null)
                throw new ArgumentNullException(nameof(serialCounts));

            int serialCount = 0;
            int totalSerialCount = serialCounts.Sum();

            if (volts == null)
                throw new InvalidOperationException("Cell voltages array is not initialized.");

            UInt16[] data = new UInt16[totalSerialCount];
            int i = 0;
            int j = 0;
            int k = 0;

            while (k < totalSerialCount)
            {
                data[k] = volts[i, j];
                k++;

                if (k >= totalSerialCount)
                    break;

                j++;

                if (j>= serialCounts[i])
                {
                    i++;
                    j = 0;
                }                              
            }

            return data;
        }

        //for문으로 구현
        public UInt16[] GetCellVoltage(int[] iSerialCnt) //매개변수 iSerialCnt를전달받음.
        {
            if (iSerialCnt == null) return null;

            int Serialcnt = 0;
            //매개변수로 전달된 각각의 iSerialCount를 반복문을 통해서 총 serialcount를 totalserial에 저장한다
            int totalSerialCount = iSerialCnt.Sum();

            //Cell전압을 불러온다.
            UInt16[] u16Data = new UInt16[totalSerialCount];

            for (int i = 0; i < iSerialCnt.Length; i++)
            {
                for (int j = 0; j < iSerialCnt[i]; j++)
                {
                    u16Data[Serialcnt] = volts[i, j];
                    if (u16Data[Serialcnt] == 0) return null;
                    Serialcnt++;

                }
            }
            return u16Data;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] beforarray = new int[] { 2,3 };
            // 데이터fmf 전달합니다.
            UInt16[,] data = new UInt16[2, 10] { { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, }, { 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 } };
            ArraytoCopy arraytoCopy = new ArraytoCopy(data);
            UInt16[] afterarray = arraytoCopy.GetCellVoltage(beforarray);

            // 1차원 배열 결과를 출력합니다.
            Console.WriteLine("Converted 1D Array:");
            foreach (var item in afterarray)
            {
                Console.Write(item + " ");

            }
            Console.ReadLine();
        }
    }

}

