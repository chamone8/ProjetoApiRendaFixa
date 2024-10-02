namespace ProjetoApiRendaFixa.CQRS.Queries
{
    public class GetAccountByIdQuery
    {
        public Guid  AccountId { get; set; }

        public GetAccountByIdQuery(Guid accountId)
        {
            AccountId = accountId;
        }
    }
}
