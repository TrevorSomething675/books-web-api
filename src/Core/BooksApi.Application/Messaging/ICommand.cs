namespace BooksApi.Application.Messaging
{
    public interface ICommand
    {

    }
    public interface ICommand<TResponse> : IBaseCommand
    {

    }
    public interface IBaseCommand
    {

    }
}