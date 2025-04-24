// <copyright file="IResult.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace ChatTool.Application.Results
{
    using System;

    /// <summary>
    /// .
    /// </summary>
    /// <typeparam name="T">..</typeparam>
    public interface IResult<out T>
    {
        /// <summary>
        /// .
        /// </summary>
        /// <typeparam name="TOut">..</typeparam>
        /// <param name="onSuccess">...</param>
        /// <param name="onFailure">....</param>
        /// <returns>.....</returns>
        IResult<TOut> Match<TOut>(Func<T, IResult<TOut>> onSuccess, Func<string, IResult<TOut>> onFailure);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="onSuccess">..</param>
        /// <param name="onFailure">...</param>
        void Extract(Action<T> onSuccess, Action onFailure);
    }
}