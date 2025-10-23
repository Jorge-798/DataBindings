namespace DataBindings.ObjetoDeDatso.Models
{
    public class Contador
    {
        private int _conteo;

        public int Conteo
        {
            get => _conteo;
            set
            {
              if (value != _conteo)
              {
                _conteo = value;
              }
            }
            
        }
        public Contador(int conteoinicial =0)
        {
            Conteo = conteoinicial;
        }

        public void Contar()
        {
            Conteo++;
        }

        public void Reiniciar() 
        {
            Conteo = 0;          
        } 
            
    }
}
