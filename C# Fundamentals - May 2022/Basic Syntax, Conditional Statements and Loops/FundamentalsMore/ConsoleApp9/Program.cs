using System;

namespace ConsoleApp9
{
    class Program
    {
        //DNA Sequences
        //You are a molecular biologist who’s on the verge of figuring out gene manipulation. But first you need to see what DNA sequences you’re working with.
        //Write a program, which prints all the possible nucleic acid sequences (A, C, G and T), in the range [AAA…TTT].
        //Each nucleic acid sequence is exactly 3 nucleotides (letters) long. Print a new line every 4 sequences.
        //Each nucleotide has a corresponding numeric value – A -> 1, C -> 2, G -> 3, T -> 4.
        //For every sequence take the sum of its elements (e.g. ACAC -> 1 + 2 + 1 + 2 = 6).
        //If it’s equal to or larger than the entered target number print the sequence with an “O” before and after it, otherwise print “X” before and after it.
        //Examples
        //Input     Output                      Input   Output                      Comments
        //5	        XAAAX XAACX OAAGO OAATO     11      XAAAX XAACX XAAGX XAATX     Combinations, where “sum >= 11”:
        //          XACAX OACCO OACGO OACTO             XACAX XACCX XACGX XACTX     GTT -> 3+4+4 -> 11
        //          OAGAO OAGCO OAGGO OAGTO             XAGAX XAGCX XAGGX XAGTX     TGT -> 4+3+4 -> 11
        //          OATAO OATCO OATGO OATTO             XATAX XATCX XATGX XATTX     TTG -> 4+4+3 -> 11
        //          XCAAX OCACO OCAGO OCATO             XCAAX XCACX XCAGX XCATX     TTT -> 4+4+4 -> 12
        //          OCCAO OCCCO OCCGO OCCTO             XCCAX XCCCX XCCGX XCCTX
        //          OCGAO OCGCO OCGGO OCGTO             XCGAX XCGCX XCGGX XCGTX
        //          OCTAO OCTCO OCTGO OCTTO             XCTAX XCTCX XCTGX XCTTX
        //          OGAAO OGACO OGAGO OGATO             XGAAX XGACX XGAGX XGATX
        //          OGCAO OGCCO OGCGO OGCTO             XGCAX XGCCX XGCGX XGCTX
        //          OGGAO OGGCO OGGGO OGGTO             XGGAX XGGCX XGGGX XGGTX
        //          OGTAO OGTCO OGTGO OGTTO             XGTAX XGTCX XGTGX OGTTO
        //          OTAAO OTACO OTAGO OTATO             XTAAX XTACX XTAGX XTATX
        //          OTCAO OTCCO OTCGO OTCTO             XTCAX XTCCX XTCGX XTCTX
        //          OTGAO OTGCO OTGGO OTGTO             XTGAX XTGCX XTGGX OTGTO
        //          OTTAO OTTCO OTTGO OTTTO             XTTAX XTTCX OTTGO OTTTO	
        //
        //Input     Output                      Comments
        //10	    XAAAX XAACX XAAGX XAATX     Combinations, where “sum >= 10”:
        //          XACAX XACCX XACGX XACTX     CTT -> 2+4+4 -> 10
        //          XAGAX XAGCX XAGGX XAGTX     GGT -> 3+3+4 -> 10
        //          XATAX XATCX XATGX XATTX     GTG -> 3+4+3 -> 10
        //          XCAAX XCACX XCAGX XCATX     GTT -> 3+4+4 -> 11
        //          XCCAX XCCCX XCCGX XCCTX     TCT -> 4+2+4 -> 10
        //          XCGAX XCGCX XCGGX XCGTX     TGG -> 4+3+3 -> 10
        //          XCTAX XCTCX XCTGX OCTTO     TGT -> 4+3+4 -> 11
        //          XGAAX XGACX XGAGX XGATX     TTC -> 4+4+2 -> 10
        //          XGCAX XGCCX XGCGX XGCTX     TTG -> 4+4+3 -> 11
        //          XGGAX XGGCX XGGGX OGGTO     TTT -> 4+4+4 -> 12
        //          XGTAX XGTCX OGTGO OGTTO
        //          XTAAX XTACX XTAGX XTATX
        //          XTCAX XTCCX XTCGX OTCTO
        //          XTGAX XTGCX OTGGO OTGTO
        //          XTTAX OTTCO OTTGO OTTTO 

        static void Main()
        {
            int target = int.Parse(Console.ReadLine());
            char[] sequence = new char[5];
            char[] nucleotides = { 'X', 'A', 'C', 'G', 'T', 'O' };

            for (int j = 1; j <= 4; j++)
            {
                for (int k = 1; k <= 4; k++)
                {
                    for (int l = 1; l <= 4; l++)
                    {
                        if (j + k + l < target)
                        {
                            sequence[0] = nucleotides[0];
                            sequence[4] = nucleotides[0];
                        }
                        else
                        {
                            sequence[0] = nucleotides[5];
                            sequence[4] = nucleotides[5];
                        }

                        sequence[1] = nucleotides[j];
                        sequence[2] = nucleotides[k];
                        sequence[3] = nucleotides[l];

                        string output = string.Join(" ", sequence);
                        output = output.Replace(" ", String.Empty);

                        if (l == 4)
                        {
                            Console.WriteLine(output);
                        }
                        else
                        {
                            Console.Write($"{output} ");
                        }
                    }
                }
            }
        }
    }
}
