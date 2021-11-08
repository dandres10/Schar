using System;

namespace Delegado
{
    public delegate void DelegadoSimple();

    public class DelegateExample
    {
        public static bool DoSomething(DelegadoSimple delegado)
        {
            try
            {
                delegado();
                return true;
            }
            catch (Exception)
            {
                return false;
                
            }
        
        }


    }
}