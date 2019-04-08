/* Fichier d'utilitaires IntUtil. */
namespace Prog2
{
    public static class IntUtil
    {
        /// <summary>
        /// Compare deux entiers entre eux.
        /// </summary>
        /// <param name="ceci"></param>
        /// <param name="cela"></param>
        /// <returns></returns>
        public static int ComparerAvec(this int ceci, int cela)
        {
            if (ceci < cela)
            {
                return -1;
            }
            else if (ceci > cela)
            {
                return +1;
            }
            else
            {
                return 0;
            }
        }
    }
}
