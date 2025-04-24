// <copyright file="Success.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace ChatTool.Application.Results
{
    using System;

    /// <summary>
    /// .
    /// </summary>
    /// <typeparam name="T">..</typeparam>
    public class Success<T> : IResult<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Success{T}"/> class.
        /// </summary>
        /// <param name="value">.</param>
        public Success(T value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets.
        /// </summary>
        public T Value { get; }

        /// <inheritdoc/>
        public IResult<TOut> Match<TOut>(Func<T, IResult<TOut>> onSuccess, Func<string, IResult<TOut>> onFailure)
        {
            return onSuccess(this.Value);
        }

        /// <inheritdoc/>
        public void Extract(Action<T> onSuccess, Action onFailure)
        {
            onSuccess(this.Value);
        }
    }
}