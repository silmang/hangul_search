using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace hangul_search
{
    class Program
    {
        static void Main(string[] args)
        {

            char[] chr = { 'ㄱ', 'ㄲ', 'ㄴ', 'ㄷ', 'ㄸ', 'ㄹ', 'ㅁ', 'ㅂ', 'ㅃ', 'ㅅ', 'ㅆ',
                           'ㅇ', 'ㅈ', 'ㅉ', 'ㅊ','ㅋ','ㅌ', 'ㅍ', 'ㅎ' };

            string[] str = { "가", "까", "나", "다", "따", "라", "마", "바", "빠", "사", "싸",
                           "아", "자", "짜", "차","카","타", "파", "하" };

            int[] chrint = {44032,44620,45208,45796,46384,46972,47560,48148,48736,49324,49912,
                               50500,51088,51676,52264,52852,53440,54028,54616,55204};


            List<string> list = new List<string>();
            list.AddRange(new List<string> { "가시나무", "소나무", "목련", "백일홍", "청단풍", "홍단풍", "가이즈까향나무", "감나무", "개나리", "금송" });
            string x = Console.ReadLine();
            string pattern = "";

            for (int i = 0; i < x.Length; i++)
            {
                //초성만 입력되었을때
                if (x[i] >= 'ㄱ' && x[i] <= 'ㅎ')
                {
                    for (int j = 0; j < chr.Length; j++)
                    {
                        if (x[i] == chr[j])
                        {
                            pattern += string.Format("[{0}-{1}]", str[j], (char)(chrint[j + 1] - 1));
                        }
                    }
                }
                //완성된 문자를 입력했을때 검색패턴 쓰기
                else if (x[i] >= '가')
                {
                    //받침이 있는지 검사
                    int magic = ((x[i] - '가') % 588);

                    //받침이 없을때.
                    if (magic == 0)
                    {
                        pattern += string.Format("[{0}-{1}]", x[i], (char)(x[i] + 27));
                    }

                    //받침이 있을때
                    else
                    {
                        magic = 27 - (magic % 28);
                        pattern += string.Format("[{0}-{1}]", x[i], (char)(x[i] + magic));
                    }
                }
                //영어를 입력했을때
                else if (x[i] >= 'A' && x[i] <= 'z')
                {
                    pattern += x[i];
                }
                //숫자를 입력했을때.
                else if (x[i] >= '0' && x[i] <= '9')
                {
                    pattern += x[i];
                }
            }
            var res = list.Where(e => Regex.IsMatch(e.ToString(), pattern));

            foreach (var c in res)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine(pattern);
            Console.ReadLine();

        }
    }
}
