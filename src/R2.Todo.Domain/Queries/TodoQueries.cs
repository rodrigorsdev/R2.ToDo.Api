using R2.Todo.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace R2.Todo.Domain.Queries
{
    public static class TodoQueries
    {
        public static Expression<Func<TodoItem, bool>> GetAll(string user)
        {
            return a => a.User == user;
        }

        public static Expression<Func<TodoItem, bool>> GetAllDone(string user)
        {
            return a => a.User == user && a.Done;
        }

        public static Expression<Func<TodoItem, bool>> GetAllUndone(string user)
        {
            return a => a.User == user && !a.Done;
        }

        public static Expression<Func<TodoItem, bool>> GetByPeriod(string user, DateTime date, bool done)
        {
            return a =>
                a.User == user &&
                a.Done == done &&
                a.Date.Date == date.Date;
        }
    }
}