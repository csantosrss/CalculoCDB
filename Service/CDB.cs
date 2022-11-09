using CalculoCDB.Models;

namespace CalculoCDB.Service
{
    public class CDB
    {
        private double TB { get; set; } = 108.00;
        private double CDI { get; set; } = 0.9;
        public Response Calcular(Request request)
        {

            double VF = 0;
            double VFCalc = 0;

            double Percentual = (CDI*TB)/100;

            for (int i = 0; i < request.Prazo; i++)
            {

                if (VF == 0)
                {
                    VF = request.Valor;
                }

                VFCalc = VF + ((VF*Percentual)/100);

                VF = VFCalc;
            }

            Imposto imposto = new Imposto();

            var percImposto = imposto.GetImposto(request.Prazo);
            var rendimento = VF - request.Valor;

            // verificar 
            Response response = new Response();
            response.Bruto = VF;
            response.Liquido = VF - ((rendimento * percImposto) / 100);

            return response;
        }
    }
}
