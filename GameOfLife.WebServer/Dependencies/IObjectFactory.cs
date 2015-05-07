namespace GameOfLife.WebServer.Dependencies
{
    using System;

    internal interface IObjectFactory
    {
        void Provide<T>(object constant);

        T Build<T>();

        object Build(Type type);
    }
}
