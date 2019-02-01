using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Menezis {

    public static class ScriptAliases {

        public static void fn_p_stJFFTXTProcedure(this Perso p, int textIndex, Vector3 position, string text, byte alpha)
        {
            Rayman2Text.DrawText(textIndex, position, text, alpha);
        }

        public static int Func_RandomInt(this Perso p, int v1, int v2)
        {
            return UnityEngine.Random.Range(v1, v2);
        }

        public static float Func_Sinus(this Perso p, float a)
        {
            return (float)Math.Sin((a / 180) * Math.PI);
        }

        public static float Func_Cosinus(this Perso p, float a)
        {
            return (float)Math.Cos((a / 180) * Math.PI);
        }

        public static async Task TIME_FrozenWait(this Perso p, int milliseconds)
        {
            await new WaitForSeconds(((float)milliseconds) / 1000.0f);
        }

        static int counter = 0;

        public static Perso Func_GenerateObject(this Perso p, Type persoType, Vector3 position)
        {
            GameObject gameObject = new GameObject("Instanciated_"+persoType.Name+"_"+counter);
            counter++;
            Perso perso = (Perso)gameObject.AddComponent(persoType);
            perso.DelayUpdate();

            return perso;
        }

        public static Perso GetPerso(this Perso p, string name)
        {
            return GameObject.Find(name)?.GetComponent<Perso>();
        }

        public static T GetPerso<T>(this Perso p, string name) where T:Perso
        {
            Perso perso = GetPerso(p, name);
            if (perso != null && perso is T) {
                return (T)perso;
            } else {
                throw new Exception("Object "+perso+" is not an instance of the requested type");
            }
        }

        public static bool Cond_IsTimeElapsed(this Perso p, int timerVariable, int timeInMilliseconds)
        {
            int globalTimer = Func_GetTime(p);
            int addedTimers = 0;

            if (globalTimer < timerVariable) {
                addedTimers = timerVariable - globalTimer;
            } else {
                addedTimers = globalTimer - timerVariable;
            }

            return addedTimers >= timeInMilliseconds;
        }

        public static float VEC_GetVectorNorm(this Perso p, Vector3 vector3)
        {
            return vector3.magnitude;
        }

        public static int Func_GetTime(this Perso p)
        {
            // Return time since level load in milliseconds
            return (int)(Time.timeSinceLevelLoad * 1000);
        }

        public static Vector3 Func_Normalize(this Perso p, Vector3 vector3)
        {
            return vector3.normalized;
        }

        // Interpolate between two vectors linearly with a certain factor. Temporal is used to indicate that it should be t
        public static Vector3 VEC_TemporalVectorCombination(this Perso p, Vector3 a, float factor, Vector3 b)
        {
            return a + (b - a) * factor;
        }

        public static int Func_Int(this Perso p, float value)
        {
            return (int)value;
        }

        public static float Func_GetDeltaTime(this Perso p) // delta time as int is gross
        {
            return Time.deltaTime * 1000.0f;
        }

        public static float VEC_AngleVector(this Perso p, Vector3 a, Vector3 b, int mode) // Dot product, mode = radians, degrees or something
        {
            float result = Vector3.Dot(a, b);
            return result;
        }

        public static void fn_p_stKillPersoAndClearVariableProcedure1(this Perso p, Perso perso)
        {
            if (perso != null && perso.gameObject != null) {
                GameObject.Destroy(perso.gameObject);
            }
        }

        public static float PadHorizontalAxis(this Perso p)
        {
            return (Input.GetAxisRaw("Horizontal") * 160) *0.5f;
        }

        public static float PadVerticalAxis(this Perso p)
        {
            return (-Input.GetAxisRaw("Vertical") * 160) * 0.5f;
        }

        public static float Func_AbsoluteValue(this Perso p, float v)
        {
            return (float)Math.Abs(v);
        }

        public static Vector3 Position(this Perso p)
        {
            return p.transform.position;
        }

        public static void Proc_ChangeOneCustomBit(this Perso p, int index, bool value)
        {
            // Rayman 2 uses indexes here that start with 1 instead of 0
            p.customBits.SetCustomBit(index - 1, value);
        }

        public static bool Cond_IsCustomBitSet(this Perso p, int index)
        {
            // Rayman 2 uses indexes here that start with 1 instead of 0
            return p.customBits.GetCustomBit(index - 1);
        }
    }
}
