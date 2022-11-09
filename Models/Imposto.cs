namespace CalculoCDB.Models
{
    public class Imposto
    {
        public List<ImpostoModel> ImpostoList { get; set; }

        public Imposto()
        {
            ImpostoList = CriarTabelaImposto();
        }

        private static List<ImpostoModel> CriarTabelaImposto()
        {
            List<ImpostoModel> ImpostoListTemp = new List<ImpostoModel>();
            AddList(ImpostoListTemp, 6, 22.5);
            AddList(ImpostoListTemp, 12, 20.00);
            AddList(ImpostoListTemp, 24, 17.5);
            AddList(ImpostoListTemp, 25, 15.00);
            return ImpostoListTemp;
        }

        private static void AddList(List<ImpostoModel> impostoListTemp, int meses, double percentual)
        {
            ImpostoModel imposto = new ImpostoModel();
            imposto.Meses = meses;
            imposto.Percentual = percentual;
            impostoListTemp.Add(imposto);
        }

        public double GetImposto(int meses)
        {
            // testar maior que 24
            var result = ImpostoList.Where(x => x.Meses >= meses).FirstOrDefault();

            return result != null ? result.Percentual : 0;

        }
    }

}
public class ImpostoModel
{
    public int Meses { get; set; }
    public double Percentual { get; set; }
}



