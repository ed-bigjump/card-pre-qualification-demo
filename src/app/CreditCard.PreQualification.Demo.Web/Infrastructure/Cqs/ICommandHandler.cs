namespace CreditCard.PreQualification.Demo.Web.Infrastructure.Cqs
{
    public interface ICommandHandler<TCommand>
    {
        void Handle(TCommand command);
    }
}
