using Task2_TP.ObjectModel;

namespace Task2_TP
{
    public class Filler
    {
        public static A GetDefaultClass()
        {
            A a = new A(null, 15);
            B b = new B(null, 30);
            C c = new C(null, 60);

            a.B = b;
            b.C = c;
            c.A = a;

            return a;
        }
    }
}
