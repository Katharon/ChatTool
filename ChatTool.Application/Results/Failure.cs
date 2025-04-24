// <copyright file="Failure.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace ChatTool.Application.Results
{
    using System;

    /// <summary>
    /// .
    /// </summary>
    /// <typeparam name="T">..</typeparam>
    public class Failure<T> : IResult<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Failure{T}"/> class.
        /// </summary>
        /// <param name="message">.</param>
        public Failure(string message)
        {
            this.Message = message;
        }

        /// <summary>
        /// Gets.
        /// </summary>
        public string Message { get; private set; }

        /// <inheritdoc/>
        public IResult<TOut> Match<TOut>(Func<T, IResult<TOut>> onSuccess, Func<string, IResult<TOut>> onFailure)
        {
            return onFailure(this.Message);
        }

        /// <inheritdoc/>
        public void Extract(Action<T> onSuccess, Action onFailure)
        {
            onFailure();
        }
    }
}