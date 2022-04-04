public class vaja1{
    public static void main(String[] args)
    {
        stevilo ulomek = new stevilo(12, 8);
        System.out.println(ulomek);
        ulomek.pokrajsaj();
    }
}
class stevilo
{
    int a;
    int b;
    public stevilo(int i, int j) 
    {
        a=i;
        b=j; 
    }
    void pokrajsaj()
    {
        int manjsi=Math.min(a, b);
        int stevec=0;
        for(int i=manjsi;i>=1;i--)
            if(a%i==0 && b%i==0)
            {
                stevec=i;
                break;
            }
        a/=stevec;
        b/=stevec;
        if(b==1)
        System.out.println(a);
        else
        System.out.println(a+"/"+b);
        
    }
}
