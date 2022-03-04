using Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Controllers
{
    public class EspecialidadeController
    {
        public static Especialidade IncluirEspecialidade(
            string Descricao,
            string Detalhamento
        )
        {
            if (String.IsNullOrEmpty(Descricao)) {
                throw new Exception("A decrição é obrigatória");
            }
            return new Especialidade(Descricao, Detalhamento);
        }

        public static Especialidade AlterarEspecialidade(
            int Id,
            string Descricao,
            string Detalhamento
        )
        {
            Especialidade especialidade = GetEspecialidade(Id);

            if (!String.IsNullOrEmpty(Descricao)) {
                especialidade.Descricao = Descricao;
            }
            especialidade.Detalhamento = Detalhamento;

            return especialidade;
        }

        public static Especialidade ExcluirEspecialidade(
            int Id
        )
        {
            Especialidade especialidade = GetEspecialidade(Id);
            Models.Especialidade.RemoverEspecialidade(especialidade);
            return especialidade;
        }

        public static List<Especialidade> VisualizarEspecialidades()
        {
            return Models.Especialidade.GetEspecialidades();  
        }

        public static Especialidade GetEspecialidade(
            int Id
        )
        {
            List<Especialidade> especialidadesModels = Models.Especialidade.GetEspecialidades();
            IEnumerable<Especialidade> Especialidades = from Especialidade in especialidadesModels
                            where Especialidade.Id == Id
                            select Especialidade;
            Especialidade especialidade = Especialidades.First();
            
            if (especialidade == null)
            {
                throw new Exception("Especialidade não encontrada");
            }

            return especialidade;
        }
    }
}