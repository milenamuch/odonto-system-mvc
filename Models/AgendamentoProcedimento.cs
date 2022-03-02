using System.Linq;
using System.Collections.Generic;

namespace Models
{
    public class AgendamentoProcedimento
    {
        public static int ID = 0;
        private static List<AgendamentoProcedimento> AgendamentoProcedimentos = new List<AgendamentoProcedimento>();
        public int Id { set; get; }
        public int IdProcedimento { set; get; }
        public Procedimento Procedimento { set; get; }
        public int IdAgendamento { set; get; }
        public Agendamento Agendamento { set; get; }


        public AgendamentoProcedimento(
            int IdProcedimento,
            int IdAgendamento
        ) : this(++ID, IdProcedimento, IdAgendamento)
        { }

        private AgendamentoProcedimento(
            int Id,
            int IdProcedimento,
            int IdAgendamento
        )
        {
            this.Id = Id;
            this.IdProcedimento = IdProcedimento;
            this.Procedimento = Procedimento.GetProcedimentos().Find(Procedimento => Procedimento.Id == IdProcedimento);
            this.IdAgendamento = IdAgendamento;
            this.Agendamento = Agendamento.GetAgendamentos().Find(Agendamento => Agendamento.Id == IdAgendamento);

            AgendamentoProcedimentos.Add(this);
        }

        public static List<AgendamentoProcedimento> GetAgendamentoProcedimentos()
        {
            return AgendamentoProcedimentos;
        }

        public static IEnumerable<AgendamentoProcedimento> GetProcedimentosPorAgendamento(int IdAgendamento)
        {
            return AgendamentoProcedimentos.FindAll(Procedimento => Procedimento.IdAgendamento == IdAgendamento);
        }

        public static double GetTotalPorAgendamento(int IdAgendamento)
        {
            return (
                from AgendamentoProcedimento in AgendamentoProcedimentos
                where AgendamentoProcedimento.IdAgendamento == IdAgendamento
                select AgendamentoProcedimento.Procedimento.Preco
            ).Sum();
        }

        public static string ImprimirPorAgendamento(int IdAgendamento)
        {
            IEnumerable<AgendamentoProcedimento> procedimentos = from AgendamentoProcedimento in AgendamentoProcedimentos
                                                                 where AgendamentoProcedimento.IdAgendamento == IdAgendamento
                                                                 select AgendamentoProcedimento;


            string ret = "Procedimentos: ";
            if (procedimentos.Count() > 0)
            {
                foreach (AgendamentoProcedimento procedimento in procedimentos)
                {
                    ret += $"\n    Procedimento: {procedimento.Procedimento.Descricao}";
                    ret += $"\n    Preco: {procedimento.Procedimento.Preco}";
                }
            }
            else
            {
                ret += "\n    Não há procedimentos.";
            }

            return ret;
        }

        public static void RemoverAgendamentoProcedimento(
            AgendamentoProcedimento agendamentoProcedimento
        )
        {
            AgendamentoProcedimentos.Remove(agendamentoProcedimento);
        }

    }
}