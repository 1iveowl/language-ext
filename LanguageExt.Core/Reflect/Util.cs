﻿using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace LanguageExt.Reflect
{
    public static class Util
    {
        /// <summary>
        /// Emits the IL to instantiate a type of R
        /// </summary>
        public static Func<A, R> CtorInvoke<A, R>(Func<ConstructorInfo, bool> ctorPred = null)
        {
            ctorPred = ctorPred ?? (_ => true);

            var ctorInfo = typeof(R)
                .GetTypeInfo()
                .DeclaredConstructors
                .Where(x =>
                {
                    var ps = x.GetParameters();
                    if (ps.Length != 1) return false;
                    if (ps[0].ParameterType != typeof(A)) return false;
                    return ctorPred(x);
                })
                .FirstOrDefault();

            if (ctorPred == null) throw new ArgumentException($"Constructor not found for type {typeof(R).FullName}");

            var ctorParams = ctorInfo.GetParameters();

            var boundType = typeof(A);
            var dynamic = new DynamicMethod("CreateInstance",
                                            ctorInfo.DeclaringType,
                                            ctorParams.Select(p => p.ParameterType).ToArray(),
                                            true);

            var il = dynamic.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Newobj, ctorInfo);
            il.Emit(OpCodes.Ret);

            return (Func<A, R>)dynamic.CreateDelegate(typeof(Func<A, R>));
        }

        /// <summary>
        /// Emits the IL to instantiate a type of R
        /// </summary>
        public static Func<A, B, R> CtorInvoke<A, B, R>(Func<ConstructorInfo, bool> ctorPred = null)
        {
            ctorPred = ctorPred ?? (_ => true);

            var ctorInfo = typeof(R)
                .GetTypeInfo()
                .DeclaredConstructors
                .Where(x =>
                {
                    var ps = x.GetParameters();
                    if (ps.Length != 2) return false;
                    if (ps[0].ParameterType != typeof(A)) return false;
                    if (ps[1].ParameterType != typeof(B)) return false;
                    return ctorPred(x);
                })
                .FirstOrDefault();

            if (ctorPred == null) throw new ArgumentException($"Constructor not found for type {typeof(R).FullName}");

            var ctorParams = ctorInfo.GetParameters();

            var boundType = typeof(A);
            var dynamic = new DynamicMethod("CreateInstance",
                                            ctorInfo.DeclaringType,
                                            ctorParams.Select(p => p.ParameterType).ToArray(),
                                            true);

            var il = dynamic.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Newobj, ctorInfo);
            il.Emit(OpCodes.Ret);

            return (Func<A, B, R>)dynamic.CreateDelegate(typeof(Func<A, B, R>));
        }

        /// <summary>
        /// Emits the IL to instantiate a type of R
        /// </summary>
        public static Func<A, B, C, R> CtorInvoke<A, B, C, R>(Func<ConstructorInfo, bool> ctorPred = null)
        {
            ctorPred = ctorPred ?? (_ => true);

            var ctorInfo = typeof(R)
                .GetTypeInfo()
                .DeclaredConstructors
                .Where(x =>
                {
                    var ps = x.GetParameters();
                    if (ps.Length != 3) return false;
                    if (ps[0].ParameterType != typeof(A)) return false;
                    if (ps[1].ParameterType != typeof(B)) return false;
                    if (ps[2].ParameterType != typeof(C)) return false;
                    return ctorPred(x);
                })
                .FirstOrDefault();

            if (ctorPred == null) throw new ArgumentException($"Constructor not found for type {typeof(R).FullName}");

            var ctorParams = ctorInfo.GetParameters();

            var boundType = typeof(A);
            var dynamic = new DynamicMethod("CreateInstance",
                                            ctorInfo.DeclaringType,
                                            ctorParams.Select(p => p.ParameterType).ToArray(),
                                            true);

            var il = dynamic.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Ldarg_2);
            il.Emit(OpCodes.Newobj, ctorInfo);
            il.Emit(OpCodes.Ret);

            return (Func<A, B, C, R>)dynamic.CreateDelegate(typeof(Func<A, B, C, R>));
        }

        /// <summary>
        /// Emits the IL to instantiate a type of R
        /// </summary>
        public static Func<A, B, C, D, R> CtorInvoke<A, B, C, D, R>(Func<ConstructorInfo, bool> ctorPred = null)
        {
            ctorPred = ctorPred ?? (_ => true);

            var ctorInfo = typeof(R)
                .GetTypeInfo()
                .DeclaredConstructors
                .Where(x =>
                {
                    var ps = x.GetParameters();
                    if (ps.Length != 4) return false;
                    if (ps[0].ParameterType != typeof(A)) return false;
                    if (ps[1].ParameterType != typeof(B)) return false;
                    if (ps[2].ParameterType != typeof(C)) return false;
                    if (ps[3].ParameterType != typeof(D)) return false;
                    return ctorPred(x);
                })
                .FirstOrDefault();

            if (ctorPred == null) throw new ArgumentException($"Constructor not found for type {typeof(R).FullName}");

            var ctorParams = ctorInfo.GetParameters();

            var boundType = typeof(A);
            var dynamic = new DynamicMethod("CreateInstance",
                                            ctorInfo.DeclaringType,
                                            ctorParams.Select(p => p.ParameterType).ToArray(),
                                            true);

            var il = dynamic.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Ldarg_2);
            il.Emit(OpCodes.Ldarg_3);
            il.Emit(OpCodes.Newobj, ctorInfo);
            il.Emit(OpCodes.Ret);

            return (Func<A, B, C, D, R>)dynamic.CreateDelegate(typeof(Func<A, B, C, D, R>));
        }
    }
}