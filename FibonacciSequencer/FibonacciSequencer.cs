using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjectEuler
{    
    public static class FibonacciSequencer
    {
        public static List<UInt64> KnownSequence { get; private set; }
        private static string KnownSequenceFileName = "FibonacciSequence.txt";

        //initialize
        static FibonacciSequencer()
        {
            KnownSequence = new List<UInt64>();

            using (StreamReader sr = new StreamReader(FibonacciSequencer.KnownSequenceFileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrEmpty(line))
                    {
                        continue;
                    }

                    KnownSequence.Add(UInt64.Parse(line));                    
                }
            }            
        }

        public static void GenerateSequence(UInt64 max)
        {
            Console.WriteLine("generating sequence up to " + max.ToString());

            int termsKnown = FibonacciSequencer.KnownSequence.Count;
            UInt64 term1 = FibonacciSequencer.KnownSequence[termsKnown - 2];
            UInt64 term2 = FibonacciSequencer.KnownSequence[termsKnown - 1];
            UInt64 newTerm;

            if (term2 >= max)
            {
                return;
            }

            uint termsGenerated = 0;
            uint totalTermsGenerated = 0;
            List<string> newTerms = new List<string>();

            while (term2 <= max)
            {
                //generate new term
                newTerm = term1 + term2;
                KnownSequence.Add(newTerm);
                newTerms.Add(newTerm.ToString());

                //write terms to file
                termsGenerated++;

                if (termsGenerated == 1000)
                {
                    totalTermsGenerated += termsGenerated;
                    Console.WriteLine(string.Format("terms generated: {0}", totalTermsGenerated.ToString()));
                    //Thread.Sleep(2000);                            

                    File.AppendAllLines(FibonacciSequencer.KnownSequenceFileName, newTerms);
                    newTerms = new List<string>();
                    termsGenerated = 0;
                }

                //setup terms for next iteration
                term1 = term2;
                term2 = newTerm;
            }

            //write stragglers to the file
            if (newTerms.Count > 0)
            {
                Console.WriteLine(string.Format("terms generated: {0}", totalTermsGenerated.ToString()));
                File.AppendAllLines(FibonacciSequencer.KnownSequenceFileName, newTerms);
            }
        }

        public static void GenerateSequenceMaxTerms(int max)
        {
            Console.WriteLine("generating sequence max terms: " + max.ToString());

            int termsKnown = FibonacciSequencer.KnownSequence.Count;

            if (termsKnown >= max)
            {
                return;
            }

            UInt64 term1 = FibonacciSequencer.KnownSequence[termsKnown - 2];
            UInt64 term2 = FibonacciSequencer.KnownSequence[termsKnown - 1];
            UInt64 newTerm;

            uint termsGenerated = 0;
            uint totalTermsGenerated = 0;
            List<string> newTerms = new List<string>();

            while (termsKnown < max)
            {
                //generate new term
                newTerm = term1 + term2;
                KnownSequence.Add(newTerm);
                newTerms.Add(newTerm.ToString());

                //write terms to file
                termsGenerated++;

                if (termsGenerated == 1000)
                {
                    totalTermsGenerated += termsGenerated;
                    Console.WriteLine(string.Format("terms generated: {0}", totalTermsGenerated.ToString()));
                    //Thread.Sleep(2000);                            

                    File.AppendAllLines(FibonacciSequencer.KnownSequenceFileName, newTerms);
                    newTerms = new List<string>();
                    termsGenerated = 0;
                }

                //setup terms for next iteration
                term1 = term2;
                term2 = newTerm;
            }

            //write stragglers to the file
            if (newTerms.Count > 0)
            {
                Console.WriteLine(string.Format("terms generated: {0}", totalTermsGenerated.ToString()));
                File.AppendAllLines(FibonacciSequencer.KnownSequenceFileName, newTerms);
            }
        }
    }
}
