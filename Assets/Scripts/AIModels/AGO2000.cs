using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Menezis.AIModels
{
    public class AGO2000 : Perso {
        public int Int_0 = 200;
        public int Int_1 = 200;
        public int Int_2 = 0;
        public int Int_3 = 0;
        public Perso Perso_4;
        public int Int_5 = 10;
        public Perso Perso_6;
        public int Int_7 = 0;
        public int Int_8 = 0;
        public int Int_9 = 0;
        public int Int_10 = 0;
        public int Int_11 = 0;
        public Vector3 Vector_12 = new Vector3(0, 0, 0);
        public int Int_13 = 0;
        public Vector3 Vector_14 = new Vector3(0, 0, 0);
        public bool Boolean_15 = false;
        public int Int_16 = 0;
        public int Int_17 = 0;
        public int Int_18 = 0;
        public int Int_19 = 0;
        public int Int_20 = 0;
        public int Int_21 = 0;
        public int Int_22 = 0;
        public int Int_23 = 0;
        public int Int_24 = 0;
        public int Int_25 = 0;
        public int Int_26 = 0;

        protected override void Start()
        {
            base.Start();

            sm.ChangeActiveRuleState(Rule_0_MIC_ship_init);
            sm.ChangeActiveReflexState(Reflex_0_MIC_ref_vide);
        }

        private IEnumerator Rule_0_MIC_ship_init()
        {
            // Script 0
            Int_26 = 1;
            Int_16 = 255;
            Int_21 += ((JFF2000)(Perso_4)).Int_32;
            if (Int_2 == 0) {
                sm.ChangeActiveRuleState(Rule_3_MIC_dec_go);
            } else {
                if (Int_2 == 1) {
                    sm.ChangeActiveRuleState(Rule_1_MIC_tir_go);
                } else {
                    if (Int_2 == 2) {
                        Int_10 = ScriptAliases.Func_GetTime();
                        Int_11 = (800 - (4 * ((JFF2000)(Perso_4)).Int_30));
                        Int_22 = 0;
                        Int_23 = 30;
                        sm.ChangeActiveRuleState(Rule_2_MIC_en1_go);
                    } else {
                        if (Int_2 == 3) {
                            Int_10 = ScriptAliases.Func_GetTime();
                            sm.ChangeActiveRuleState(Rule_4_MIC_bul_enn_go);
                        } else {
                            if (Int_2 == 4) {
                                Int_17 = 0;
                                Int_10 = ScriptAliases.Func_GetTime();
                                Int_23 = 30;
                                Int_22 = 0;
                                sm.ChangeActiveRuleState(Rule_6_MIC_en4_go);
                            } else {
                                if (Int_2 == 5) {
                                    Int_10 = ScriptAliases.Func_GetTime();
                                    Int_18 = 180;
                                    Int_19 = 0;
                                    Int_22 = 1;
                                    Int_23 = 40;
                                    sm.ChangeActiveRuleState(Rule_7_MIC_en5_go);
                                } else {
                                    if (Int_2 == 6) {
                                        Int_10 = ScriptAliases.Func_GetTime();
                                        Int_18 = Int_1;
                                        Int_23 = 50;
                                        Int_22 = 2;
                                        sm.ChangeActiveRuleState(Rule_8_MIC_en6_go);
                                    } else {
                                        if (Int_2 == 7) {
                                            Int_10 = ScriptAliases.Func_GetTime();
                                            Int_18 = 0;
                                            Int_0 += Int_23;
                                            Int_1 += Int_23;
                                            Int_18 = Int_23;
                                            sm.ChangeActiveRuleState(Rule_9_MIC_flash);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // Script 1
            if (Int_2 == 8) {
                Int_18 = 0;
                Int_19 = 0;
                Int_20 = 0;
                Int_23 = 30;
                Int_10 = ScriptAliases.Func_GetTime();
                sm.ChangeActiveRuleState(Rule_10_DS1_power_up);
            } else {
                if (Int_2 == 9) {
                    Int_23 = 30;
                    Int_22 = 2;
                    sm.ChangeActiveRuleState(Rule_11_DS1_en9_go);
                }
            }

            yield return null;
        }

        private IEnumerator Rule_1_MIC_tir_go()
        {
            // Script 0
            Int_0 += (17 * Int_26);
            if (Int_0 > 1000 || Cond_IsCustomBitSet(28)) {
                if (((JFF2000)(Perso_4)).Perso_7 == this) {
                    ((JFF2000)(Perso_4)).Boolean_10 = false;
                } else {
                    if (((JFF2000)(Perso_4)).Perso_8 == this) {
                        ((JFF2000)(Perso_4)).Boolean_11 = false;
                    } else {
                        if (((JFF2000)(Perso_4)).Perso_9 == this) {
                            ((JFF2000)(Perso_4)).Boolean_12 = false;
                        }
                    }
                }
                StartCoroutine(Macro_8());
            } else {
                ScriptAliases.fn_p_stJFFTXTProcedure(Int_5, new Vector3(Int_0, Int_1, 30), "/o600:.", 255);
            }

            yield return null;
        }

        private IEnumerator Rule_2_MIC_en1_go()
        {
            // Script 0
            Int_0 += (Int_8 * Int_26);
            Int_1 += (Int_9 * Int_26);
            if (globalRandomizer % 4 == 0 && (Int_0 < -200)) {
                StartCoroutine(Macro_8());
            }

            // Script 1
            StartCoroutine(Macro_7());
            StartCoroutine(Macro_12());
            if (globalRandomizer % 4 == 0 && (ScriptAliases.Cond_IsTimeElapsed(Int_10, Int_11))) {
                Int_10 = ScriptAliases.Func_GetTime();
                Int_25 = 10;
                StartCoroutine(Macro_9());
            }

            // Script 2
            Int_7 = 3;
            StartCoroutine(Macro_6());

            yield return null;
        }

        private IEnumerator Rule_3_MIC_dec_go()
        {
            // Script 0
            Int_0 -= (4 * Int_26);
            if (Int_0 < -162) {
                Int_0 += 162;
            }

            // Script 1
            ScriptAliases.fn_p_stJFFTXTProcedure(Int_5, new Vector3(Int_0, Int_1, 80), "/o600:xxxxxxxx", 255);

            yield return null;
        }

        private IEnumerator Rule_4_MIC_bul_enn_go()
        {
            // Script 0
            if (Int_17 != 0) {
                Vector_14 = ScriptAliases.Func_Normalize(new Vector3(((JFF2000)(Perso_4)).Int_0, ((JFF2000)(Perso_4)).Int_1, 0) - new Vector3(Int_0, Int_1, 0));
                Vector_12 = ScriptAliases.VEC_TemporalVectorCombination(Vector_14, 0.1f, ScriptAliases.Func_Normalize(new Vector3(Int_8, Int_9, 0)));
                Int_8 = ScriptAliases.Func_Int((Vector_12.x * 15));
                Int_9 = ScriptAliases.Func_Int((Vector_12.y * 15));
            }

            // Script 1
            Int_0 += (Int_8 * Int_26);
            Int_1 += (Int_9 * Int_26);
            if (Boolean_15) {
                ScriptAliases.fn_p_stJFFTXTProcedure(Int_5, new Vector3(Int_0, Int_1, 30), "/o200:.", 255);
                Boolean_15 = false;
            } else {
                ScriptAliases.fn_p_stJFFTXTProcedure(Int_5, new Vector3(Int_0, Int_1, 30), "/o400:.", 255);
                Boolean_15 = true;
            }

            // Script 2
            StartCoroutine(Macro_2());
            if (globalRandomizer % 2 == 0 && (!(Perso_4.Cond_IsCustomBitSet(29)))) {
                if (ScriptAliases.VEC_GetVectorNorm(new Vector3((((JFF2000)(Perso_4)).Int_0 + ((JFF2000)(Perso_4)).Int_19), (((JFF2000)(Perso_4)).Int_1 + ((JFF2000)(Perso_4)).Int_19), 0) - new Vector3((Int_0 + 30), (Int_1 + 55), 0)) < ((10 + ((JFF2000)(Perso_4)).Int_19) * 0.8)) {
                    Perso_4.Proc_ChangeOneCustomBit(28, true);
                    StartCoroutine(Macro_8());
                }
            }

            // Script 3
            if (globalRandomizer % 8 == 0 && (ScriptAliases.Cond_IsTimeElapsed(Int_10, 2500))) {
                StartCoroutine(Macro_8());
            }

            yield return null;
        }

        private IEnumerator Rule_5_MIC_en1_paf()
        {
            // Script 0
            Int_0 += (3 * Int_26);
            Int_1 += (Int_9 * Int_26);
            if (globalRandomizer % 4 == 0 && (Int_0 < -200 || Int_1 > 1000 || Int_16 < 15)) {
                StartCoroutine(Macro_8());
            } else {
                if (Boolean_15) {
                    Int_24 = 0;
                    StartCoroutine(Macro_7());
                    Boolean_15 = false;
                } else {
                    Int_24 = 1;
                    StartCoroutine(Macro_7());
                    Boolean_15 = true;
                }
            }

            // Script 1
            Int_9 += Int_26;
            if (Int_16 > 6) {
                Int_16 -= 6;
            }

            yield return null;
        }

        private IEnumerator Rule_6_MIC_en4_go()
        {
            // Script 0
            if (Int_17 == 0) {
                Int_0 += (Int_8 * Int_26);
                Int_1 += (Int_9 * Int_26);
                if (Int_9 > 0) {
                    Int_9 += Int_26;
                    if (Int_1 >= ((JFF2000)(Perso_4)).Int_1) {
                        Int_17 += 1;
                    }
                } else {
                    Int_9 -= Int_26;
                    if (Int_1 <= ((JFF2000)(Perso_4)).Int_1) {
                        Int_17 += 1;
                    }
                }
                if (Int_17 == 1) {
                    if (((JFF2000)(Perso_4)).Int_23 <= 26) {
                        Perso_6 = ScriptAliases.Func_GenerateObject(GetType(), ScriptAliases.GetPerso("StdCamer").Position());
                        if (Perso_6 != null) {
                            StartCoroutine(Macro_4());
                            ((AGO2000)(Perso_6)).Perso_4 = Perso_4;
                            ((AGO2000)(Perso_6)).Int_5 = Int_13;
                            ((AGO2000)(Perso_6)).Int_0 = Int_0;
                            ((AGO2000)(Perso_6)).Int_1 = Int_1;
                            ((AGO2000)(Perso_6)).Int_8 = (-8 - ((JFF2000)(Perso_4)).Int_31);
                            ((AGO2000)(Perso_6)).Int_9 = 0;
                            ((AGO2000)(Perso_6)).Int_2 = 3;
                            //ScriptAliases.GetPerso("StdCamer").SOUND_SendSoundRequest(SoundEvent(122947080));
                            //ScriptAliases.GetPerso("StdCamer").SOUND_SetVolumeAnim(30);
                        }
                    }
                }
            } else {
                Int_0 += (Int_8 * Int_26);
                if (Int_8 >= -(15 + ((JFF2000)(Perso_4)).Int_31)) {
                    Int_8 -= Int_26;
                }
                Int_1 += (Int_9 * Int_26);
                if (Int_9 > 0) {
                    if (Int_9 <= 2) {
                        Int_9 = 0;
                    } else {
                        Int_9 -= 3;
                    }
                } else {
                    if (Int_9 >= -2) {
                        Int_9 = 0;
                    } else {
                        Int_9 += 3;
                    }
                }
            }

            // Script 1
            if (Int_0 < -200) {
                StartCoroutine(Macro_8());
            } else {
                StartCoroutine(Macro_7());
            }

            // Script 2
            StartCoroutine(Macro_12());
            Int_7 = 5;
            StartCoroutine(Macro_6());

            yield return null;
        }

        private IEnumerator Rule_7_MIC_en5_go()
        {
            // Script 0
            Int_0 += (Int_8 * Int_26);
            Int_1 += (Int_9 * Int_26);
            if (Int_0 < -200) {
                StartCoroutine(Macro_8());
            } else {
                StartCoroutine(Macro_7());
            }

            // Script 1
            if (Int_17 == 0) {
                if (ScriptAliases.Cond_IsTimeElapsed(Int_10, Int_11)) {
                    if (ScriptAliases.Cond_IsTimeElapsed(Int_10, (4000 + Int_11))) {
                        Int_17 += 1;
                        Int_8 = -2;
                    } else {
                        Int_8 = 0;
                        Int_9 = 0;
                        if (ScriptAliases.Cond_IsTimeElapsed(Int_19, 100)) {
                            Int_25 = 10;
                            StartCoroutine(Macro_11());
                            Int_18 += Int_20;
                            Int_19 = ScriptAliases.Func_GetTime();
                        }
                    }
                }
            } else {
                if (ScriptAliases.Cond_IsTimeElapsed(Int_19, 100)) {
                    Int_25 = 10;
                    StartCoroutine(Macro_11());
                    Int_18 += Int_20;
                    Int_19 = ScriptAliases.Func_GetTime();
                }
            }

            // Script 2
            Int_7 = 15;
            StartCoroutine(Macro_6());

            yield return null;
        }

        private IEnumerator Rule_8_MIC_en6_go()
        {
            // Script 0
            Int_0 += (Int_8 * Int_26);
            Int_1 += (Int_9 * Int_26);
            if (Int_17 == 0) {
                Int_9 += Int_26;
                if (Int_1 >= Int_18) {
                    Int_9 = -15;
                    Int_1 = Int_18;
                }
            } else {
                Int_9 -= Int_26;
                if (Int_1 <= Int_18) {
                    Int_9 = 15;
                    Int_1 = Int_18;
                }
            }

            // Script 1
            if (Int_0 < -100 || Int_0 > 1000) {
                if (Int_19 == 0) {
                    StartCoroutine(Macro_8());
                } else {
                    Int_8 = -Int_8;
                    Int_19 -= 1;
                }
            }

            // Script 2
            StartCoroutine(Macro_7());
            StartCoroutine(Macro_12());
            if (ScriptAliases.Cond_IsTimeElapsed(Int_10, Int_11)) {
                Int_10 = ScriptAliases.Func_GetTime();
                Int_11 = (ScriptAliases.Func_RandomInt(3000, 5000) - (10 * ((JFF2000)(Perso_4)).Int_30));
                Int_25 = 10;
                StartCoroutine(Macro_10());
            }

            // Script 3
            Int_7 = 10;
            StartCoroutine(Macro_6());

            yield return null;
        }

        private IEnumerator Rule_9_MIC_flash()
        {
            // Script 0
            if (!(Int_19!=0)) { // unsure
                Int_18 += (int)((5 * ScriptAliases.Func_GetDeltaTime()) / 16);
            } else {
                Int_18 += (int)((5 * ScriptAliases.Func_GetDeltaTime()) / 32);
            }

            // Script 1
            if (((Int_18 * 4) - Int_23) > 255) {
                StartCoroutine(Macro_8());
            } else {
                if (Int_22 == 0) {
                    ScriptAliases.fn_p_stJFFTXTProcedure(Int_5, new Vector3((Int_0 - Int_18), (Int_1 - Int_18), Int_18), "/o600:x", (byte)((255 + Int_23) - (Int_18 * 4)));
                } else {
                    if (Int_22 == 1) {
                        ScriptAliases.fn_p_stJFFTXTProcedure(Int_5, new Vector3((Int_0 - Int_18), (Int_1 - Int_18), Int_18), "/o600:o", (byte)((255 + Int_23) - (Int_18 * 4)));
                    } else {
                        ScriptAliases.fn_p_stJFFTXTProcedure(Int_5, new Vector3((Int_0 - Int_18), (Int_1 - Int_18), Int_18), "/o600:e", (byte)((255 + Int_23) - (Int_18 * 4)));
                    }
                }
            }

            yield return null;
        }

        private IEnumerator Rule_10_DS1_power_up()
        {
            // Script 0
            Int_18 += (8 * Int_26);
            Int_19 += Int_26;
            Int_8 = ScriptAliases.Func_Int((ScriptAliases.Func_Sinus(Int_18) * (15 + (40 * ScriptAliases.Func_Sinus(Int_19)))));
            Int_9 = ScriptAliases.Func_Int((ScriptAliases.Func_Cosinus(Int_18) * (15 + (40 * ScriptAliases.Func_Sinus(Int_19)))));
            if (ScriptAliases.Cond_IsTimeElapsed(Int_10, 8000)) {
                if (ScriptAliases.Cond_IsTimeElapsed(Int_10, (8000 + 4000))) {
                    StartCoroutine(Macro_8());
                } else {
                    Int_20 = (ScriptAliases.Func_RandomInt(201, 255) - (((ScriptAliases.Func_GetTime() - Int_10) - 8000) / 20));
                }
            } else {
                Int_20 += (6 * Int_26);
                if (Int_20 > 255) {
                    Int_20 -= 200;
                }
            }

            // Script 1
            if (ScriptAliases.VEC_GetVectorNorm(new Vector3((((JFF2000)(Perso_4)).Int_0 + ((JFF2000)(Perso_4)).Int_19), (((JFF2000)(Perso_4)).Int_1 + ((JFF2000)(Perso_4)).Int_19), 0) - new Vector3((Int_0 + Int_23), (Int_1 + Int_23), 0)) < (((JFF2000)(Perso_4)).Int_19 + Int_23)) {
                ((JFF2000)(Perso_4)).Int_22 += 1;
                //ScriptAliases.GetPerso("StdCamer").SOUND_SendSoundRequest(SoundEvent(122577408));
                //ScriptAliases.GetPerso("StdCamer").SOUND_SetVolumeAnim(120);
                StartCoroutine(Macro_8());
            }

            // Script 2
            ScriptAliases.fn_p_stJFFTXTProcedure(Int_5, new Vector3((Int_0 + Int_8), (Int_1 + Int_9), Int_23), "/o400:!", (byte)Int_20);

            yield return null;
        }

        private IEnumerator Rule_11_DS1_en9_go()
        {
            // Script 0
            if (Int_17 == 0) {
                if (!(Int_0 > 15)) {
                    Int_0 += Int_26;
                } else {
                    Int_17 += 1;
                    Int_10 = ScriptAliases.Func_GetTime();
                    Int_20 = 7;
                }
            } else {
                if (Int_17 == 2) {
                    if (!(Int_0 < (-Int_23 - Int_23))) {
                        Int_0 -= Int_26;
                    } else {
                        StartCoroutine(Macro_8());
                    }
                } else {
                    if (ScriptAliases.Cond_IsTimeElapsed(Int_10, (1500 - (5 * ((JFF2000)(Perso_4)).Int_30)))) {
                        Int_25 = (6 + ScriptAliases.Func_RandomInt(0, 4));
                        Vector_12 = ScriptAliases.Func_Normalize(new Vector3(((JFF2000)(Perso_4)).Int_0, ((JFF2000)(Perso_4)).Int_1, 0) - new Vector3(Int_0, Int_1, 0));
                        Int_19 = -ScriptAliases.Func_Int(ScriptAliases.VEC_AngleVector(new Vector3(1, 0, 0), Vector_12, 0));
                        Int_25 = (6 + ScriptAliases.Func_RandomInt(0, 4));
                        Int_18 = (Int_19 - 18);
                        StartCoroutine(Macro_11());
                        yield return ScriptAliases.TIME_FrozenWait(1);
                        Int_25 = (6 + ScriptAliases.Func_RandomInt(0, 4));
                        Int_18 = (Int_19 - 12);
                        StartCoroutine(Macro_11());
                        yield return ScriptAliases.TIME_FrozenWait(1);
                        Int_18 = (Int_19 - 6);
                        Int_25 = (6 + ScriptAliases.Func_RandomInt(0, 4));
                        StartCoroutine(Macro_11());
                        yield return ScriptAliases.TIME_FrozenWait(1);
                        Int_18 = Int_19;
                        Int_25 = (6 + ScriptAliases.Func_RandomInt(0, 4));
                        StartCoroutine(Macro_11());
                        yield return ScriptAliases.TIME_FrozenWait(1);
                        Int_18 = (Int_19 + 6);
                        Int_25 = (6 + ScriptAliases.Func_RandomInt(0, 4));
                        StartCoroutine(Macro_11());
                        yield return ScriptAliases.TIME_FrozenWait(1);
                        Int_18 = (Int_19 + 12);
                        Int_25 = (6 + ScriptAliases.Func_RandomInt(0, 4));
                        StartCoroutine(Macro_11());
                        Int_18 = (Int_19 + 18);
                        Int_25 = (6 + ScriptAliases.Func_RandomInt(0, 4));
                        StartCoroutine(Macro_11());
                        Int_10 = ScriptAliases.Func_GetTime();
                        if (Int_20 == 1) {
                            Int_17 += 1;
                        } else {
                            Int_20 -= 1;
                        }
                    }
                }
            }

            // Script 1
            StartCoroutine(Macro_7());
            StartCoroutine(Macro_15());

            yield return null;
        }

        private IEnumerator Reflex_0_MIC_ref_vide()
        {
            // Script 0
            Int_26 = ScriptAliases.Func_Int((ScriptAliases.Func_GetDeltaTime() * 0.0625f));
            if (Perso_4.Cond_IsCustomBitSet(30)) {
                StartCoroutine(Macro_8());
            }

            yield return null;
        }

        private IEnumerator Macro_0()
        {
            if (ScriptAliases.VEC_GetVectorNorm(new Vector3((((AGO2000)(Perso_6)).Int_0 + 30), (((AGO2000)(Perso_6)).Int_1 + 54), 0) - new Vector3((Int_0 + Int_23), (Int_1 + Int_23), 0)) < ((Int_23 + ((AGO2000)(Perso_6)).Int_23) * 1.5)) {
                Proc_ChangeOneCustomBit(29, true);
                Perso_6.Proc_ChangeOneCustomBit(28, true);
                if (!(Int_21!=0)) {
                    //ScriptAliases.GetPerso("StdCamer").SOUND_SendSoundRequest(SoundEvent(122806064));
                    //ScriptAliases.GetPerso("StdCamer").SOUND_SetVolumeAnim(120);
                    if (Perso_4.Cond_IsCustomBitSet(31)) {
                        StartCoroutine(Macro_13());
                    }
                    StartCoroutine(Macro_1());
                    Int_9 = -20;
                    Int_16 = 255;
                    sm.ChangeActiveRuleState(Rule_5_MIC_en1_paf);
                } else {
                    Int_7 = 1;
                    StartCoroutine(Macro_1());
                    StartCoroutine(Macro_14());
                    Int_21 -= 1;
                    //SOUND_SendSoundRequest(SoundEvent(122758312));
                    //SOUND_SetVolumeAnim(120);
                }
            }

            yield return null; ;
        }

        private IEnumerator Macro_1()
        {
            ((JFF2000)(Perso_4)).Int_13 += Int_7;

            yield return null;
        }

        private IEnumerator Macro_2()
        {
            if (globalRandomizer % 4 == 0 && (true)) {
                if (Int_0 > 1000) {
                    StartCoroutine(Macro_8());
                } else {
                    if (Int_0 < (2 * -Int_23)) {
                        StartCoroutine(Macro_8());
                    }
                }
                if (Int_1 > 1000) {
                    StartCoroutine(Macro_8());
                } else {
                    if (Int_1 < (2 * -Int_23)) {
                        StartCoroutine(Macro_8());
                    }
                }
            }

            yield return null;
        }

        private IEnumerator Macro_4()
        {
            Int_13 = ((JFF2000)(Perso_4)).Int_4;
            for (int i = 0; i < 50; i++) {

                if (ScriptAliases.GetPerso<World>("World").IntegerArray_25[Int_13] == 0) {
                    ((JFF2000)(Perso_4)).Int_4 = Int_13;
                    ScriptAliases.GetPerso<World>("World").IntegerArray_25[Int_13] = 1;
                    break;
                }

                Int_13 += 1;
                if (Int_13 > 45) {
                    Int_13 = 10;
                }
            }
            ((JFF2000)(Perso_4)).Int_4 += 1;
            ((JFF2000)(Perso_4)).Int_23 += 1;
            if (((JFF2000)(Perso_4)).Int_4 > 45) {
                ((JFF2000)(Perso_4)).Int_4 = 10;
            }

            yield return null;
        }

        private IEnumerator Macro_5()
        {
            ScriptAliases.GetPerso<World>("World").IntegerArray_25[Int_5] = 0;
            ((JFF2000)(Perso_4)).Int_23 -= 1;

            yield return null;
        }

        private IEnumerator Macro_6()
        {
            if (((JFF2000)(Perso_4)).Boolean_10) {
                Perso_6 = ((JFF2000)(Perso_4)).Perso_7;
                StartCoroutine(Macro_0());
            }
            if (!(Cond_IsCustomBitSet(29)) && ((JFF2000)(Perso_4)).Boolean_11) {
                Perso_6 = ((JFF2000)(Perso_4)).Perso_8;
                StartCoroutine(Macro_0());
            }
            if (!(Cond_IsCustomBitSet(29)) && ((JFF2000)(Perso_4)).Boolean_12) {
                Perso_6 = ((JFF2000)(Perso_4)).Perso_9;
                StartCoroutine(Macro_0());
            }
            Proc_ChangeOneCustomBit(29, false);

            yield return null;
        }

        private IEnumerator Macro_7()
        {
            if (Int_22 == 0) {
                if (Int_24 == 0) {
                    ScriptAliases.fn_p_stJFFTXTProcedure(Int_5, new Vector3(Int_0, Int_1, Int_23), "/o200:x", (byte)Int_16);
                } else {
                    ScriptAliases.fn_p_stJFFTXTProcedure(Int_5, new Vector3(Int_0, Int_1, Int_23), "/o600:x", (byte)Int_16);
                }
            } else {
                if (Int_22 == 1) {
                    if (Int_24 == 0) {
                        ScriptAliases.fn_p_stJFFTXTProcedure(Int_5, new Vector3(Int_0, Int_1, Int_23), "/o200:0", (byte)Int_16);
                    } else {
                        ScriptAliases.fn_p_stJFFTXTProcedure(Int_5, new Vector3(Int_0, Int_1, Int_23), "/o600:0", (byte)Int_16);
                    }
                } else {
                    if (Int_22 == 2) {
                        ScriptAliases.fn_p_stJFFTXTProcedure(Int_5, new Vector3(Int_0, Int_1, Int_23), "/o200:8", (byte)Int_16);
                    }
                }
            }

            yield return null;
        }

        private IEnumerator Macro_8()
        {
            ScriptAliases.fn_p_stJFFTXTProcedure(Int_5, new Vector3(0, 0, 0), "/o200:x", 0);
            StartCoroutine(Macro_5());
            ScriptAliases.fn_p_stKillPersoAndClearVariableProcedure1(this);

            yield return null;
        }

        private IEnumerator Macro_9()
        {
            if (((JFF2000)(Perso_4)).Int_23 < 25) {
                Perso_6 = ScriptAliases.Func_GenerateObject(GetType(), ScriptAliases.GetPerso("StdCamer").Position());
                if (Perso_6 != null) {
                    Vector_12 = ScriptAliases.Func_Normalize(new Vector3(((JFF2000)(Perso_4)).Int_0, ((JFF2000)(Perso_4)).Int_1, 0) - new Vector3(Int_0, Int_1, 0));
                    StartCoroutine(Macro_4());
                    ((AGO2000)(Perso_6)).Perso_4 = Perso_4;
                    ((AGO2000)(Perso_6)).Int_5 = Int_13;
                    ((AGO2000)(Perso_6)).Int_0 = Int_0;
                    ((AGO2000)(Perso_6)).Int_1 = Int_1;
                    ((AGO2000)(Perso_6)).Int_8 = ScriptAliases.Func_Int((Vector_12.x * (Int_25 + ((JFF2000)(Perso_4)).Int_31)));
                    ((AGO2000)(Perso_6)).Int_9 = ScriptAliases.Func_Int((Vector_12.y * (Int_25 + ((JFF2000)(Perso_4)).Int_31)));
                    ((AGO2000)(Perso_6)).Int_2 = 3;
                    ((AGO2000)(Perso_6)).Int_17 = 0;
                    //SOUND_SendSoundRequest(SoundEvent(122465704));
                    //SOUND_SetVolumeAnim(60);
                }
            }

            yield return null;
        }

        private IEnumerator Macro_10()
        {
            if (((JFF2000)(Perso_4)).Int_23 < 25) {
                Perso_6 = ScriptAliases.Func_GenerateObject(GetType(), ScriptAliases.GetPerso("StdCamer").Position());
                if (Perso_6 != null) {
                    Vector_12 = ScriptAliases.Func_Normalize(new Vector3(((JFF2000)(Perso_4)).Int_0, ((JFF2000)(Perso_4)).Int_1, 0) - new Vector3(Int_0, Int_1, 0));
                    StartCoroutine(Macro_4());
                    ((AGO2000)(Perso_6)).Perso_4 = Perso_4;
                    ((AGO2000)(Perso_6)).Int_5 = Int_13;
                    ((AGO2000)(Perso_6)).Int_0 = Int_0;
                    ((AGO2000)(Perso_6)).Int_1 = Int_1;
                    ((AGO2000)(Perso_6)).Int_8 = ScriptAliases.Func_Int((Vector_12.x * (Int_25 + ((JFF2000)(Perso_4)).Int_31)));
                    ((AGO2000)(Perso_6)).Int_9 = ScriptAliases.Func_Int((Vector_12.y * (Int_25 + ((JFF2000)(Perso_4)).Int_31)));
                    ((AGO2000)(Perso_6)).Int_2 = 3;
                    ((AGO2000)(Perso_6)).Int_17 = 1;
                    //SOUND_SendSoundRequest(SoundEvent(123169304));
                    //SOUND_SetVolumeAnim(60);
                }
            }

            yield return null;
        }

        private IEnumerator Macro_11()
        {
            if (((JFF2000)(Perso_4)).Int_23 < 25) {
                Perso_6 = ScriptAliases.Func_GenerateObject(GetType(), ScriptAliases.GetPerso("StdCamer").Position());
                if (Perso_6 != null) {
                    StartCoroutine(Macro_4());
                    ((AGO2000)(Perso_6)).Perso_4 = Perso_4;
                    ((AGO2000)(Perso_6)).Int_5 = Int_13;
                    ((AGO2000)(Perso_6)).Int_0 = (Int_0 + 13);
                    ((AGO2000)(Perso_6)).Int_1 = (Int_1 - 15);
                    ((AGO2000)(Perso_6)).Int_8 = ScriptAliases.Func_Int((ScriptAliases.Func_Cosinus(Int_18) * (Int_25 + ((JFF2000)(Perso_4)).Int_31)));
                    ((AGO2000)(Perso_6)).Int_9 = -ScriptAliases.Func_Int((ScriptAliases.Func_Sinus(Int_18) * (Int_25 + ((JFF2000)(Perso_4)).Int_31)));
                    ((AGO2000)(Perso_6)).Int_2 = 3;
                    //SOUND_SendSoundRequest(SoundEvent(122465704));
                    //SOUND_SetVolumeAnim(60);
                }
            }

            yield return null;
        }

        private IEnumerator Macro_12()
        {
            if (globalRandomizer % 2 == 0 && (!(Perso_4.Cond_IsCustomBitSet(29)))) {
                if (ScriptAliases.VEC_GetVectorNorm(new Vector3((((JFF2000)(Perso_4)).Int_0 + 30), (((JFF2000)(Perso_4)).Int_1 + 30), 0) - new Vector3((Int_0 + 40), (Int_1 + 40), 0)) < 70) {
                    Perso_4.Proc_ChangeOneCustomBit(28, true);
                    Int_9 = -20;
                    Int_16 = 255;
                    //SOUND_SendSoundRequest(SoundEvent(122806064));
                    //SOUND_SetVolumeAnim(60);
                    sm.ChangeActiveRuleState(Rule_5_MIC_en1_paf);
                }
            }

            yield return null;
        }

        private IEnumerator Macro_13()
        {
            if (((JFF2000)(Perso_4)).Int_23 < 25) {
                Perso_6 = ScriptAliases.Func_GenerateObject(GetType(), ScriptAliases.GetPerso("StdCamer").Position());
                if (Perso_6 != null) {
                    StartCoroutine(Macro_4());
                    ((AGO2000)(Perso_6)).Perso_4 = Perso_4;
                    ((AGO2000)(Perso_6)).Int_5 = Int_13;
                    ((AGO2000)(Perso_6)).Int_0 = Int_0;
                    ((AGO2000)(Perso_6)).Int_1 = Int_1;
                    ((AGO2000)(Perso_6)).Int_2 = 8;
                    Perso_4.Proc_ChangeOneCustomBit(31, false);
                }
            }

            yield return null;
        }

        private IEnumerator Macro_14()
        {
            if (((JFF2000)(Perso_4)).Int_23 < 25) {
                Perso_6 = ScriptAliases.Func_GenerateObject(GetType(), ScriptAliases.GetPerso("StdCamer").Position());
                if (Perso_6!=null) {
                    StartCoroutine(Macro_4());
                    ((AGO2000)(Perso_6)).Perso_4 = Perso_4;
                    ((AGO2000)(Perso_6)).Int_5 = Int_13;
                    ((AGO2000)(Perso_6)).Int_0 = Int_0;
                    ((AGO2000)(Perso_6)).Int_1 = Int_1;
                    ((AGO2000)(Perso_6)).Int_2 = 7;
                    ((AGO2000)(Perso_6)).Int_22 = Int_22;
                    ((AGO2000)(Perso_6)).Int_23 = Int_23;
                }
            }

            yield return null;
        }

        private IEnumerator Macro_15()
        {
            if (globalRandomizer % 2 == 0 && (!(Perso_4.Cond_IsCustomBitSet(29)))) {
                if (ScriptAliases.VEC_GetVectorNorm(new Vector3((((JFF2000)(Perso_4)).Int_0 + 30), (((JFF2000)(Perso_4)).Int_1 + 30), 0) - new Vector3((Int_0 + 40), (Int_1 + 40), 0)) < 70) {
                    Perso_4.Proc_ChangeOneCustomBit(28, true);
                }
            }

            yield return null;
        }
    }
}
