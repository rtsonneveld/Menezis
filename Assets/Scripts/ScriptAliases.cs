using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Menezis {

    // Used to make it easier to find back functions
    public abstract class ScriptAliases {

        public static void fn_p_stJFFTXTProcedure(int textIndex, Vector3 position, string text, byte alpha)
        {
            Rayman2Text.DrawText(textIndex, position, text, alpha);
        }

        public static int Func_RandomInt(int v1, int v2)
        {
            return UnityEngine.Random.Range(v1, v2);
        }

        public static float Func_Sinus(float a)
        {
            return (float)Math.Sin((a / 180) * Math.PI);
        }

        public static float Func_Cosinus(float a)
        {
            return (float)Math.Cos((a / 180) * Math.PI);
        }

        public static IEnumerator TIME_FrozenWait(int milliseconds)
        {
            yield return new WaitForSeconds(((float)milliseconds) / 1000.0f);
        }

        static int counter = 0;

        public static Perso Func_GenerateObject(Type persoType, Vector3 position)
        {
            GameObject gameObject = new GameObject("Instanciated_"+persoType.Name+"_"+counter);
            counter++;
            Perso perso = (Perso)gameObject.AddComponent(persoType);
            perso.DelayUpdate();

            return perso;
        }

        public static Perso GetPerso(string name)
        {
            return GameObject.Find(name)?.GetComponent<Perso>();
        }

        public static T GetPerso<T>(string name) where T:Perso
        {
            Perso perso = GetPerso(name);
            if (perso != null && perso is T) {
                return (T)perso;
            } else {
                throw new Exception("Object "+perso+" is not an instance of the requested type");
            }
        }

        public static bool Cond_IsTimeElapsed(int timerVariable, int timeInMilliseconds)
        {
            int globalTimer = Func_GetTime();
            int addedTimers = 0;

            if (globalTimer < timerVariable) {
                addedTimers = timerVariable - globalTimer;
            } else {
                addedTimers = globalTimer - timerVariable;
            }

            return addedTimers >= timeInMilliseconds;
        }

        public static float VEC_GetVectorNorm(Vector3 vector3)
        {
            return vector3.magnitude;
        }

        public static int Func_GetTime()
        {
            // Return time since level load in milliseconds
            return (int)(Time.timeSinceLevelLoad * 1000);
        }

        public static Vector3 Func_Normalize(Vector3 vector3)
        {
            return vector3.normalized;
        }

        // Interpolate between two vectors linearly with a certain factor. Temporal is used to indicate that it should be t
        public static Vector3 VEC_TemporalVectorCombination(Vector3 a, float factor, Vector3 b)
        {
            return a + (b - a) * factor;
        }

        public static int Func_Int(float value)
        {
            return (int)value;
        }

        public static float Func_GetDeltaTime() // delta time as int is gross
        {
            return Time.deltaTime * 1000.0f;
        }

        public static float VEC_AngleVector(Vector3 a, Vector3 b, int mode) // Dot product, mode = radians, degrees or something
        {
            float result = Vector3.Dot(a, b);
            return result;
        }

        public static void fn_p_stKillPersoAndClearVariableProcedure1(Perso perso)
        {
            if (perso != null && perso.gameObject != null) {
                GameObject.Destroy(perso.gameObject);
            }
        }

        public static float PadHorizontalAxis()
        {
            return (Input.GetAxisRaw("Horizontal") * 160);
        }

        public static float PadVerticalAxis()
        {
            return (-Input.GetAxisRaw("Vertical") * 160);
        }

        public static float Func_AbsoluteValue(float v)
        {
            return (float)Math.Abs(v);
        }
    }
}
