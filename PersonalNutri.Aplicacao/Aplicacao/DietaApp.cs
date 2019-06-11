using PersonalNutri.Dominio.Entidades;
using PersonalNutri.Dominio.Interfaces;

namespace PersonalNutri.Aplicacao.Aplicacao
{
    public class DietaApp
    {
        private readonly IServicoDeDieta _servicoDeDieta;
        public DietaApp(IServicoDeDieta servicoDeDieta)
        {
            _servicoDeDieta = servicoDeDieta;
        }

        public Dieta CriarDieta(decimal metaDeConsumoCalorico)
        {
            var dieta  = new Dieta(_servicoDeDieta, metaDeConsumoCalorico);
            return dieta;
        }
    }
}
