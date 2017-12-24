﻿using System;
using System.Data;

namespace StoredProcedureEFCore
{
  /// <summary>
  /// Stored procedure builder
  /// </summary>
  public interface IStoredProcBuilder : IDisposable
  {
    /// <summary>
    /// Add parameter
    /// </summary>
    /// <param name="name">Name of the parameter</param>
    /// <param name="val">Value of the parameter</param>
    /// <returns></returns>
    IStoredProcBuilder AddParam(string name, object val);

    /// <summary>
    /// Add in/out parameter
    /// </summary>
    /// <typeparam name="T">Type of the parameter</typeparam>
    /// <param name="name">Name of the parameter</param>
    /// <param name="val">Value of the parameter</param>
    /// <param name="outParam">Created parameteter. Value will be populated after calling <see cref="Exec(Action{IDataReader})"/></param>
    /// <returns></returns>
    IStoredProcBuilder AddInputOutputParam<T>(string name, T val, out IOutParam<T> outParam);

    /// <summary>
    /// Add out parameter
    /// </summary>
    /// <typeparam name="T">Type of the parameter</typeparam>
    /// <param name="name">Name of the parameter</param>
    /// <param name="outParam">Created parameteter. Value will be populated after calling <see cref="Exec(Action{IDataReader})"/></param>
    /// <returns></returns>
    IStoredProcBuilder AddOutputParam<T>(string name, out IOutParam<T> outParam);

    /// <summary>
    /// Add return value parameter
    /// </summary>
    /// <typeparam name="T">Type of the parameter</typeparam>
    /// <param name="retParam">Created parameteter. Value will be populated after calling <see cref="Exec(Action{IDataReader})"/></param>
    /// <returns></returns>
    IStoredProcBuilder ReturnValue<T>(out IOutParam<T> retParam);

    /// <summary>
    /// Execute the stored procedure
    /// </summary>
    /// <param name="action">Actions to do with the result sets</param>
    void Exec(Action<IDataReader> action);

    /// <summary>
    /// Execute the stored procedure
    /// </summary>
    void ExecNonQuery();

    /// <summary>
    /// Execute the stored procedure and return the first column of the first row
    /// </summary>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="val"></param>
    void ExecScalar<T>(out T val);
  }
}
