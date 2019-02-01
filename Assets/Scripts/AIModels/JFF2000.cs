using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Menezis.AIModels {
    public class JFF2000 : Perso {

        // DSG-vars:
        public int Int_0 = 200;
        public int Int_1 = 200;
        public int Int_2 = 0;
        public Perso Perso_3;
        public int Int_4 = 10;
        public Perso Perso_5;
        public int Int_6 = 0;
        public Perso Perso_7;
        public Perso Perso_8;
        public Perso Perso_9;
        public bool Boolean_10 = false;
        public bool Boolean_11 = false;
        public bool Boolean_12 = false;
        public int Int_13_Score = 0;
        public int Int_14 = 0;
        public int Int_15 = 0;
        public int Int_16_Lives = 2;
        public int Int_17 = 0;
        public bool Boolean_18 = false;
        public int Int_19 = 0;
        public float Float_20 = 0;
        public int Int_21 = 0;
        public int Int_22 = 0;
        public int Int_23 = 0;
        public int Int_24 = 0;
        public int Int_25 = 0;
        public int Int_26 = 0;
        public int Int_27 = 0;
        public int Int_28 = 0;
        public int Int_29 = 0;
        public int Int_30 = 0;
        public int Int_31 = 0;
        public int Int_32 = 0;
        public int Int_33 = 0;
        public int Int_34 = 0;

        protected override void Start()
        {
            base.Start();

            // Normally done in Levelstaff_10.Rule_3, but now done ourselves
            Perso_3 = this;
            //

            smRule.SetState(Rule_0_Init);
            smReflex.SetState(Reflex_0_Rien);
        }

        #region Rules

        private async Task Rule_0_Init()
        {
            await Macro_8();
            ScriptAliases.fn_p_stJFFTXTProcedure(0, new Vector3(0, 300, 20), "/o200:/c:cheat", 255);

            await ScriptAliases.TIME_FrozenWait(1000); // 1 second instead of 3

            await Macro_6();
            smRule.SetState(Rule_3_Intro);
            smReflex.SetState(Reflex_0_Rien);
        }

        private async Task Rule_1_Go()
        {
            // script 0
            await Macro_4();
            if (Input.GetButtonDown("Fire1")) {
                if (!(Boolean_10)) {
                    await Macro_3();
                    if (Perso_5!=null) {
                        Boolean_10 = true;
                        Perso_7 = Perso_5;
                    }
                } else {
                    if (!(Boolean_11)) {
                        await Macro_3();
                        if (Perso_5!=null) {
                            Boolean_11 = true;
                            Perso_8 = Perso_5;
                        }
                    } else {
                        if (!(Boolean_12)) {
                            await Macro_3();
                            if (Perso_5!=null) {
                                Boolean_12 = true;
                                Perso_9 = Perso_5;
                            }
                        }
                    }
                }
            }

            // script 1
            if (ScriptAliases.Cond_IsTimeElapsed(Int_17, 3000)) {
                ScriptAliases.fn_p_stJFFTXTProcedure(0, new Vector3(Int_0, Int_1, Int_19), "/o600:e", 255);
                Proc_ChangeOneCustomBit(29, false);
            } else {
                if (Boolean_18) {
                    ScriptAliases.fn_p_stJFFTXTProcedure(0, new Vector3(Int_0, Int_1, Int_19), "/o600:e", 255);
                    Boolean_18 = false;
                } else {
                    ScriptAliases.fn_p_stJFFTXTProcedure(0, new Vector3(0, 0, 0), "/o600:e", 0);
                    Boolean_18 = true;
                }
            }

            // script 2
            if (globalRandomizer % 2 == 0 && (Cond_IsCustomBitSet(28))) {
                //ScriptAliases.GetPerso("StdCamer").SOUND_SendSoundRequest(SoundEvent(122465640));
                //ScriptAliases.GetPerso("StdCamer").SOUND_SetVolumeAnim(120);
                if (Int_16_Lives == 0) {
                    //SOUND_SendSoundRequest(SoundEvent(122618424));
                    Int_6 = ScriptAliases.Func_GetTime();
                    await Macro_6();
                    Int_0 = 0;
                    Proc_ChangeOneCustomBit(30, true);
                    //Proc_FactorAnimationFrameRate(1);
                    smRule.SetState(Rule_4_End); //Proc_ChangeMyComportAndMyReflex(JFF2000.Rule[4]["MIC_jff_jump"], JFF2000.Reflex[0]["MIC_jff_rien"]);
                    smReflex.SetState(Reflex_0_Rien); //Proc_ChangeMyComportAndMyReflex(JFF2000.Rule[4]["MIC_jff_jump"], JFF2000.Reflex[0]["MIC_jff_rien"]);
                }
                Int_16_Lives -= 1;
                if (((JFF2000)(Perso_3)).Int_23 < 25) {
                    Perso_5 = ScriptAliases.Func_GenerateObject(typeof(AGO2000), ScriptAliases.GetPerso("StdCamer").Position());
                    if (Perso_5 != null) {
                        await Macro_1();
                        ((AGO2000)(Perso_5)).Perso_4 = Perso_3;
                        ((AGO2000)(Perso_5)).Int_5_TextLayer = Int_15;
                        ((AGO2000)(Perso_5)).Int_0_X = Int_0;
                        ((AGO2000)(Perso_5)).Int_1_Y = Int_1;
                        ((AGO2000)(Perso_5)).Int_2 = 7;
                        ((AGO2000)(Perso_5)).Int_22 = 2;
                        ((AGO2000)(Perso_5)).Int_23_Size = Int_19;
                        ((AGO2000)(Perso_5)).Int_19 = 1;
                    }
                }
                Proc_ChangeOneCustomBit(28, false);
                Proc_ChangeOneCustomBit(29, true);
                Int_17 = ScriptAliases.Func_GetTime();
            }

            // script 3
            if (Input.GetButtonDown("Jump") && Int_22 > 0) {
                Int_22 -= 1;
                Int_21 = 0;
                Int_0 += Int_19;
                Int_1 += Int_19;
                Proc_ChangeOneCustomBit(29, true);
                //ScriptAliases.GetPerso("StdCamer").SOUND_SendSoundRequest(SoundEvent(122523024));
                //ScriptAliases.GetPerso("StdCamer").SOUND_SetVolumeAnim(120);
                smRule.SetState(Rule_2_Jump);
            }

            // script 4
            await Macro_0();
            await Macro_10();
        }

        private async Task Rule_2_Jump()
        {
            // Script 0

            await Macro_4();

            Int_21 += (int)((2 * ScriptAliases.Func_GetDeltaTime()) / 16);
            if (Int_21 > 180) {
                Proc_ChangeOneCustomBit(29, false);
                Int_0 -= Int_19;
                Int_1 -= Int_19;
                smRule.SetState(Rule_1_Go);
            } else {
                Float_20 = ScriptAliases.Func_AbsoluteValue((ScriptAliases.Func_Sinus(Int_21) * 60));
                ScriptAliases.fn_p_stJFFTXTProcedure(0, new Vector3(((Int_0 - Int_19) - Float_20), ((Int_1 - Int_19) - Float_20), (Int_19 + Float_20)), "/o600:e", 255);
                await Macro_0();
            }

        }

        private async Task Rule_3_Intro()
        {
            ScriptAliases.fn_p_stJFFTXTProcedure(0, new Vector3(0, 180, 20), "/o200:/c:welcome to", 255);
            ScriptAliases.fn_p_stJFFTXTProcedure(1, new Vector3(0, 260, 48), "/o600:/c:menezis 2.0", (byte)ScriptAliases.Func_RandomInt(150, 255));
            ScriptAliases.fn_p_stJFFTXTProcedure(2, new Vector3(0, 420, 14), "/o200:/c:the full text mini shoot'em up", 255);
            ScriptAliases.fn_p_stJFFTXTProcedure(7, new Vector3(0, 490, 12), "/o600:/c:a port by the people from raym.app <3", 255);
            ScriptAliases.fn_p_stJFFTXTProcedure(3, new Vector3(100, (620 - 40), 14), "/o400:- use joy to move", 255);
            ScriptAliases.fn_p_stJFFTXTProcedure(4, new Vector3(100, (665 - 40), 14), "/o400:- use /o800:a/o400: to protect", 255);
            ScriptAliases.fn_p_stJFFTXTProcedure(5, new Vector3(100, (710 - 40), 14), "/o400:- use /o800:b/o400: (or space) to shoot", 255);
            ScriptAliases.fn_p_stJFFTXTProcedure(6, new Vector3(100, 860, 18), "/o400:/c:press /o800:a/o400: or /o800:b/o400: to play", (byte)Mathf.Abs((ScriptAliases.Func_Sinus(Int_0) * 255)));
            Int_0 += 5;

            if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump")) {
                await Macro_5();
                await Macro_7();
                //Proc_FactorAnimationFrameRate(1);


                ScriptAliases.fn_p_stJFFTXTProcedure(7, new Vector3(0, 490, 12), "", 0);

                smRule.SetState(Rule_1_Go);
                smReflex.SetState(Reflex_1_Generator);
            }
        }

        private async Task Rule_4_End()
        {
            // Script 0
            ScriptAliases.fn_p_stJFFTXTProcedure(0, new Vector3(0, 280, 45), "/o600:/c:game over", (byte)ScriptAliases.Func_RandomInt(150, 255));
            ScriptAliases.fn_p_stJFFTXTProcedure(1, new Vector3(100, 500, 18), "/o200:/c:your score", 255);
            //StartCoroutine(Macro_9()); format string ourselves
            //TEXT_FormatText("/c:", "                                                  ", "                                                  ");
            ScriptAliases.fn_p_stJFFTXTProcedure(2, new Vector3(100, 560, 18), "/o400:/c:"+Int_13_Score.ToString("D4"), 255);
            ScriptAliases.fn_p_stJFFTXTProcedure(6, new Vector3(100, 860, 18), "/o400:/c:press /o800:a/o400: or /o800:b/o400: to continue", (byte)ScriptAliases.Func_AbsoluteValue((ScriptAliases.Func_Sinus(Int_0) * 255)));
            Int_0 += 5;
            if (ScriptAliases.Cond_IsTimeElapsed(Int_6, 1000)) {
                if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1")) {
                    await Macro_5();
                    await Macro_7();
                    //Proc_FactorAnimationFrameRate(1);
                    //Proc_ChangeMyComportAndMyReflex(MIC_JFF2000.Rule[3]["MIC_jff_end"], MIC_JFF2000.Reflex[0]["MIC_jff_rien"]);
                    smRule.SetState(Rule_3_Intro);
                    smReflex.SetState(Reflex_0_Rien);
                }
            }

        }

        #endregion

        #region Reflexes

        private async Task Reflex_0_Rien()
        {
            
        }


        private async Task Reflex_1_Generator()
        {
            // Script 0
            /*if (Cond_JustPressedBut(EntryAction(KeyPressed(Escape)))) {
                Proc_ChangeMap("menu");
            }*/

            // Script 1
            if (globalRandomizer % 4 == 0 && (true)) {
                await Macro_11();
            }

            // Script 2
            if (globalRandomizer % 4 == 0 && (((JFF2000)(Perso_3)).Int_23 < 25)) {
                if (Int_28 == 1) {
                    if (!(ScriptAliases.Cond_IsTimeElapsed(Int_26, 10000))) {
                        if (ScriptAliases.Cond_IsTimeElapsed(Int_27, Int_14)) {
                            Int_14 = (ScriptAliases.Func_RandomInt(700, 1500) - (Int_30 * 3));
                            Int_27 = ScriptAliases.Func_GetTime();
                            await Macro_17();
                        }
                    } else {
                        Int_28 += 1;
                        Int_14 = 3000;
                        Int_27 = ScriptAliases.Func_GetTime();
                        Int_26 = ScriptAliases.Func_GetTime();
                    }
                } else {
                    if (Int_28 == 2) {
                        if (ScriptAliases.Cond_IsTimeElapsed(Int_26, Int_14)) {
                            await Macro_14();
                            if (Int_31 > 2) {
                                await Macro_15();
                            }
                            Int_28 += 1;
                            Int_14 = 3500;
                            Int_27 = ScriptAliases.Func_GetTime();
                            Int_26 = ScriptAliases.Func_GetTime();
                        }
                    } else {
                        if (Int_28 == 3) {
                            if (!(ScriptAliases.Cond_IsTimeElapsed(Int_26, 15000))) {
                                if (ScriptAliases.Cond_IsTimeElapsed(Int_27, Int_14)) {
                                    Int_14 = (ScriptAliases.Func_RandomInt(700, 1500) - (Int_30 * 3));
                                    Int_27 = ScriptAliases.Func_GetTime();
                                    if (ScriptAliases.Func_RandomInt(0, 100) > 80) {
                                        await Macro_12();
                                    } else {
                                        await Macro_17();
                                    }
                                }
                            } else {
                                Int_28 += 1;
                                Int_14 = 800;
                                Int_27 = ScriptAliases.Func_GetTime();
                                Int_26 = ScriptAliases.Func_GetTime();
                            }
                        } else {
                            if (Int_28 == 4) {
                                if (!(ScriptAliases.Cond_IsTimeElapsed(Int_26, 12000))) {
                                    if (ScriptAliases.Cond_IsTimeElapsed(Int_27, Int_14)) {
                                        Int_14 = (ScriptAliases.Func_RandomInt(1000, 1600) - (Int_30 * 4));
                                        Int_27 = ScriptAliases.Func_GetTime();
                                        if (ScriptAliases.Func_RandomInt(0, 100) > 60) {
                                            await Macro_12();
                                            await Macro_13();
                                        } else {
                                            if (ScriptAliases.Func_RandomInt(0, 100) > 30) {
                                                await Macro_12();
                                            } else {
                                                await Macro_13();
                                            }
                                            await Macro_17();
                                        }
                                    }
                                } else {
                                    Int_28 += 1;
                                    Int_14 = 1000;
                                    Int_27 = ScriptAliases.Func_GetTime();
                                    Int_26 = ScriptAliases.Func_GetTime();
                                }
                            } else {
                                if (Int_28 == 5) {
                                    if (!(ScriptAliases.Cond_IsTimeElapsed(Int_26, 8000))) {
                                        if (ScriptAliases.Cond_IsTimeElapsed(Int_27, Int_14)) {
                                            Int_14 = (ScriptAliases.Func_RandomInt(700, 1500) - (Int_30 * 3));
                                            Int_27 = ScriptAliases.Func_GetTime();
                                            await Macro_17();
                                        }
                                    } else {
                                        Int_28 += 1;
                                        Int_14 = 600;
                                        Int_27 = ScriptAliases.Func_GetTime();
                                        Int_26 = ScriptAliases.Func_GetTime();
                                    }
                                } else {
                                    if (Int_28 == 6) {
                                        if (ScriptAliases.Cond_IsTimeElapsed(Int_26, Int_14)) {
                                            await Macro_16();
                                            Int_28 += 1;
                                            Int_14 = 600;
                                            Int_27 = ScriptAliases.Func_GetTime();
                                            Int_26 = ScriptAliases.Func_GetTime();
                                            Int_34 = 14;
                                        }
                                    } else {
                                        if (Int_28 == 7) {
                                            if (!(ScriptAliases.Cond_IsTimeElapsed(Int_26, 30000))) {
                                                if (ScriptAliases.Cond_IsTimeElapsed(Int_27, Int_14)) {
                                                    Int_14 = (ScriptAliases.Func_RandomInt(1000, 1500) - (Int_30 * 2));
                                                    Int_27 = ScriptAliases.Func_GetTime();
                                                    Int_34 -= 1;
                                                    if (Int_34 == 0) {
                                                        Int_34 = 14;
                                                        await Macro_18();
                                                    } else {
                                                        await Macro_17();
                                                    }
                                                }
                                            } else {
                                                Int_28 = 1;
                                                Int_14 = 1500;
                                                Int_27 = ScriptAliases.Func_GetTime();
                                                Int_26 = ScriptAliases.Func_GetTime();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }

        #endregion

        #region Macros

        private async Task Macro_0()
        {
            if (Int_0 > 900) {
                Int_0 = 900;
            } else {
                if (Int_0 < 20) {
                    Int_0 = 20;
                }
            }
            if (Int_1 > 900) {
                Int_1 = 900;
            } else {
                if (Int_1 < 20) {
                    Int_1 = 20;
                }
            }

        }

        private async Task Macro_1()
        {
            Int_15 = Int_4;
            for (int i = 0; i < 50; i++) {
                if (ScriptAliases.GetPerso<World>("World").IntegerArray_25[Int_15] == 0) {
                    Int_4 = Int_15;
                    ScriptAliases.GetPerso<World>("World").IntegerArray_25[Int_15] = 1;
                    break;
                }
                Int_15 += 1;
                if (Int_15 > 45) {
                    Int_15 = 10;
                }
            }
            Int_4 += 1;
            Int_23 += 1;
            if (Int_4 > 45) {
                ((JFF2000)(Perso_3)).Int_4 = 10;
            }

        }

        private async Task Macro_2()
        {
            ScriptAliases.GetPerso<World>("World").IntegerArray_25[Int_4] = 0;
            Int_23 -= 1;

        }

        private async Task Macro_3()
        {
            Perso_5 = ScriptAliases.Func_GenerateObject(typeof(AGO2000), ScriptAliases.GetPerso("StdCamer").Position());
            if (Perso_5 != null) {
                await Macro_1();
                ((AGO2000)(Perso_5)).Perso_4 = Perso_3;
                ((AGO2000)(Perso_5)).Int_5_TextLayer = Int_15;
                ((AGO2000)(Perso_5)).Int_0_X = Int_0;
                ((AGO2000)(Perso_5)).Int_1_Y = (Int_1 - 20);
                ((AGO2000)(Perso_5)).Int_2 = 1;
                //ScriptAliases.GetPerso("StdCamer").SOUND_SendSoundRequest(SoundEvent(122964480));
                //ScriptAliases.GetPerso("StdCamer").SOUND_SetVolumeAnim(30);
            }

        }

        private async Task Macro_4()
        {
            //ScriptAliases.GetPerso("StdCamer").PAD_ReadAnalogJoystickMarioMode(ScriptAliases.GetPerso("Rayman").Float_74, 1, 0, ScriptAliases.GetPerso("Rayman").Float_73, 1, 1, 1);
            Int_0 += (int)((ScriptAliases.PadHorizontalAxis() * ScriptAliases.Func_GetDeltaTime()) / 160); // padhorizontalaxis changed to float
            Int_1 += (int)((ScriptAliases.PadVerticalAxis() * ScriptAliases.Func_GetDeltaTime()) / 160);

        }

        private async Task Macro_5()
        {
            ScriptAliases.fn_p_stJFFTXTProcedure(0, new Vector3(0, 0, 0), "/o200:o", 0);
            ScriptAliases.fn_p_stJFFTXTProcedure(1, new Vector3(0, 0, 0), "/o200:o", 0);
            ScriptAliases.fn_p_stJFFTXTProcedure(2, new Vector3(0, 0, 0), "/o200:o", 0);
            ScriptAliases.fn_p_stJFFTXTProcedure(3, new Vector3(0, 0, 0), "/o200:o", 0);
            ScriptAliases.fn_p_stJFFTXTProcedure(4, new Vector3(0, 0, 0), "/o200:o", 0);
            ScriptAliases.fn_p_stJFFTXTProcedure(5, new Vector3(0, 0, 0), "/o200:o", 0);
            ScriptAliases.fn_p_stJFFTXTProcedure(6, new Vector3(0, 0, 0), "/o200:o", 0);

        }

        private async Task Macro_6()
        {
            ScriptAliases.fn_p_stJFFTXTProcedure(0, new Vector3(0, 0, 0), "/o600:e", 0);
            ScriptAliases.fn_p_stJFFTXTProcedure(1, new Vector3(0, 0, 0), "/o600:e", 0);
            ScriptAliases.fn_p_stJFFTXTProcedure(2, new Vector3(0, 0, 0), "/o600:e", 0);
            ScriptAliases.fn_p_stJFFTXTProcedure(3, new Vector3(0, 0, 0), "/o600:e", 0);

        }

        private async Task Macro_7()
        {
            Int_19 = 30;
            Int_6 = ScriptAliases.Func_GetTime();
            Int_17 = (ScriptAliases.Func_GetTime() - 10000);
            Int_14 = 2000;
            Int_0 = 200;
            Int_1 = 500;
            Boolean_10 = false;
            Boolean_11 = false;
            Boolean_12 = false;
            Int_16_Lives = 2;
            Int_22 = 3;
            Int_13_Score = 0;
            Int_24 = 0;
            Int_25 = 0;
            Int_28 = 1;
            Int_30 = 0;
            Int_31 = 0;
            Int_32 = 0;
            Int_29 = 0;
            Int_26 = ScriptAliases.Func_GetTime();
            Int_27 = ScriptAliases.Func_GetTime();
            Int_23 = 0;
            Int_14 = 1000;
            Proc_ChangeOneCustomBit(28, false);
            Proc_ChangeOneCustomBit(29, false);
            Proc_ChangeOneCustomBit(30, false);
            Proc_ChangeOneCustomBit(31, false);
        }

        private async Task Macro_8()
        {
            ScriptAliases.fn_p_stKillPersoAndClearVariableProcedure1(ScriptAliases.GetPerso("DS1_Goldorak_I1"));
            //ScriptAliases.fn_p_stKillPersoAndClearVariableProcedure1(ScriptAliases.GetPerso("World")); why kill world what
            ScriptAliases.fn_p_stKillPersoAndClearVariableProcedure1(ScriptAliases.GetPerso("DS1_OLD_THX_trav"));
            ScriptAliases.fn_p_stKillPersoAndClearVariableProcedure1(ScriptAliases.GetPerso("DS1_Goldorak_I1"));
            //ScriptAliases.GetPerso("DS1_THX_BlaBla_I1").Proc_ChangeOneCustomBit(30, true);
            ScriptAliases.fn_p_stKillPersoAndClearVariableProcedure1(ScriptAliases.GetPerso("DS1_staff_pirate_I1"));
            //ScriptAliases.GetPerso("DS1_lamort_I2").Proc_ChangeOneCustomBit(17, true);
            //ScriptAliases.GetPerso("DS1_lamort_I2").Proc_TransparentDisplay(0);
            //ScriptAliases.Proc_FixePositionPerso(Me, fn_p_stGetWpAbsolutePosition(WayPoint.FromOffset(staff_10 | 0x00061B47)));
            //ScriptAliases.GetPerso("StdCamer").Cam_SetFlagNoLinearParsing(0, 1);
            //ScriptAliases.GetPerso("StdCamer").Cam_SetFlagNoTargetParsing(0, 1);
            //ScriptAliases.GetPerso("StdCamer").Cam_ForcePosition(0, 1, fn_p_stGetWpAbsolutePosition(WayPoint.FromOffset(staff_10 | 0x00061B47)));
            //ScriptAliases.GetPerso("StdCamer").Cam_ForceTarget(0, 1, fn_p_stGetWpAbsolutePosition(WayPoint.FromOffset(staff_10 | 0x00061B2F)));
            
            //yield return ScriptAliases.TIME_FrozenWait(1);

            ScriptAliases.GetPerso("StdCamer").Proc_ChangeOneCustomBit(16, true);
            ScriptAliases.GetPerso("StdCamer").Proc_ChangeOneCustomBit(17, true);
            //ScriptAliases.GetPerso("Rayman").Proc_ChangeOneCustomBit(17, true);
            //ScriptAliases.Proc_FixePositionPerso(this, ScriptAliases.GetPerso("StdCamer").Position());


        }

        private async Task Macro_9()
        {
            /*Proc_IntToText("                                                  ", Int_13);
            if (Int_13 < 10) {
                TEXT_FormatText("/o400:000", "                                                  ", "                                                  ");
            } else {
                if (Int_13 < 100) {
                    TEXT_FormatText("/o400:00", "                                                  ", "                                                  ");
                } else {
                    if (Int_13 < 1000) {
                        TEXT_FormatText("/o400:0", "                                                  ", "                                                  ");
                    } else {
                        TEXT_FormatText("/o400:", "                                                  ", "                                                  ");
                    }
                }
            }*/

        }

        private async Task Macro_10()
        {
            if ((Int_13_Score - Int_24) >= 50) {
                Int_24 += 50;
                if (Int_22 <= 10) {
                    Proc_ChangeOneCustomBit(31, true);
                }
            }
            if ((Int_13_Score - Int_25) >= 100) {
                Int_25 += 100;
                if (Int_16_Lives <= 10) {
                    Int_16_Lives += 1;
                    //ScriptAliases.GetPerso("StdCamer").SOUND_SendSoundRequest(SoundEvent(107613776));
                    //ScriptAliases.GetPerso("StdCamer").SOUND_SetVolumeAnim(120);
                }
            }
            if ((Int_13_Score - Int_29) >= 200) {
                Int_29 += 200;
                if (Int_30 != 100) {
                    Int_30 += 10;
                }
                if (Int_31 != 15) {
                    Int_31 += 1;
                }
                if (Int_33 != 10) {
                    Int_33 += 1;
                }
            }

        }

        private async Task Macro_11()
        {
            // StartCoroutine(Macro_9()); format string ourselves
            ScriptAliases.fn_p_stJFFTXTProcedure(1, new Vector3(770, 120, 20), "/o400:" + Int_13_Score.ToString("D4"), 200);
            if (Int_16_Lives == 0) {
                ScriptAliases.fn_p_stJFFTXTProcedure(2, new Vector3(70, 120, 20), "/o400:", 0);
            } else {
                if (Int_16_Lives == 1) {
                    ScriptAliases.fn_p_stJFFTXTProcedure(2, new Vector3(70, 120, 20), "/o400:e", 127);
                } else {
                    if (Int_16_Lives == 2) {
                        ScriptAliases.fn_p_stJFFTXTProcedure(2, new Vector3(70, 120, 20), "/o400:e e", 127);
                    } else {
                        ScriptAliases.fn_p_stJFFTXTProcedure(2, new Vector3(70, 120, 20), "/o400:e e e", 127);
                    }
                }
            }
            if (Int_22 == 0) {
                ScriptAliases.fn_p_stJFFTXTProcedure(3, new Vector3(0, 0, 0), "/o400:", 0);
            } else {
                if (Int_22 == 1) {
                    ScriptAliases.fn_p_stJFFTXTProcedure(3, new Vector3((760 + 134), 880, 20), "/o400:!", 127);
                } else {
                    if (Int_22 == 2) {
                        ScriptAliases.fn_p_stJFFTXTProcedure(3, new Vector3((760 + 67), 880, 20), "/o400:! !", 127);
                    } else {
                        ScriptAliases.fn_p_stJFFTXTProcedure(3, new Vector3(760, 880, 20), "/o400:! ! !", 127);
                    }
                }
            }

        }

        private async Task Macro_12()
        {
            Perso_5 = ScriptAliases.Func_GenerateObject(typeof(AGO2000), ScriptAliases.GetPerso("StdCamer").Position());
            if (Perso_5 != null) {
                await Macro_1();
                ((AGO2000)(Perso_5)).Perso_4 = Perso_3;
                ((AGO2000)(Perso_5)).Int_5_TextLayer = Int_15;
                ((AGO2000)(Perso_5)).Int_0_X = ScriptAliases.Func_RandomInt(700, 850);
                ((AGO2000)(Perso_5)).Int_2 = 4;
                ((AGO2000)(Perso_5)).Int_8_XSpeed = ScriptAliases.Func_RandomInt(-3, 1);
                ((AGO2000)(Perso_5)).Int_21 = 0;
                ((AGO2000)(Perso_5)).Int_1_Y = -30;
                ((AGO2000)(Perso_5)).Int_9_YSpeed = 1;
            }

        }

        private async Task Macro_13()
        {
            Perso_5 = ScriptAliases.Func_GenerateObject(typeof(AGO2000), ScriptAliases.GetPerso("StdCamer").Position());
            if (Perso_5 != null) {
                await Macro_1();
                ((AGO2000)(Perso_5)).Perso_4 = Perso_3;
                ((AGO2000)(Perso_5)).Int_5_TextLayer = Int_15;
                ((AGO2000)(Perso_5)).Int_0_X = ScriptAliases.Func_RandomInt(700, 850);
                ((AGO2000)(Perso_5)).Int_2 = 4;
                ((AGO2000)(Perso_5)).Int_8_XSpeed = ScriptAliases.Func_RandomInt(-3, 1);
                ((AGO2000)(Perso_5)).Int_21 = 0;
                ((AGO2000)(Perso_5)).Int_1_Y = 1000;
                ((AGO2000)(Perso_5)).Int_9_YSpeed = -1;
            }

        }

        private async Task Macro_14()
        {
            Perso_5 = ScriptAliases.Func_GenerateObject(typeof(AGO2000), ScriptAliases.GetPerso("StdCamer").Position());
            if (Perso_5 != null) {
                await Macro_1();
                ((AGO2000)(Perso_5)).Perso_4 = Perso_3;
                ((AGO2000)(Perso_5)).Int_5_TextLayer = Int_15;
                ((AGO2000)(Perso_5)).Int_0_X = 1000;
                ((AGO2000)(Perso_5)).Int_1_Y = ScriptAliases.Func_RandomInt(200, 400);
                ((AGO2000)(Perso_5)).Int_8_XSpeed = ScriptAliases.Func_RandomInt(-4, -3);
                ((AGO2000)(Perso_5)).Int_9_YSpeed = ScriptAliases.Func_RandomInt(-1, 1);
                ((AGO2000)(Perso_5)).Int_2 = 5;
                ((AGO2000)(Perso_5)).Int_11 = ScriptAliases.Func_RandomInt(800, 2000);
                ((AGO2000)(Perso_5)).Int_21 = 15;
                ((AGO2000)(Perso_5)).Int_20 = 20;
            }

        }

        private async Task Macro_15()
        {
            Perso_5 = ScriptAliases.Func_GenerateObject(typeof(AGO2000), ScriptAliases.GetPerso("StdCamer").Position());
            if (Perso_5 != null) {
                await Macro_1();
                ((AGO2000)(Perso_5)).Perso_4 = Perso_3;
                ((AGO2000)(Perso_5)).Int_5_TextLayer = Int_15;
                ((AGO2000)(Perso_5)).Int_0_X = 1000;
                ((AGO2000)(Perso_5)).Int_1_Y = ScriptAliases.Func_RandomInt(550, 700);
                ((AGO2000)(Perso_5)).Int_8_XSpeed = ScriptAliases.Func_RandomInt(-4, -3);
                ((AGO2000)(Perso_5)).Int_9_YSpeed = ScriptAliases.Func_RandomInt(-1, 1);
                ((AGO2000)(Perso_5)).Int_2 = 5;
                ((AGO2000)(Perso_5)).Int_11 = ScriptAliases.Func_RandomInt(800, 2000);
                ((AGO2000)(Perso_5)).Int_21 = 15;
                ((AGO2000)(Perso_5)).Int_20 = -20;
            }

        }

        private async Task Macro_16()
        {
            Perso_5 = ScriptAliases.Func_GenerateObject(typeof(AGO2000), ScriptAliases.GetPerso("StdCamer").Position());
            if (Perso_5 != null) {
                await Macro_1();
                ((AGO2000)(Perso_5)).Perso_4 = Perso_3;
                ((AGO2000)(Perso_5)).Int_5_TextLayer = Int_15;
                ((AGO2000)(Perso_5)).Int_0_X = -30;
                ((AGO2000)(Perso_5)).Int_1_Y = ScriptAliases.Func_RandomInt(300, 700);
                ((AGO2000)(Perso_5)).Int_2 = 9;
            }

        }

        private async Task Macro_17()
        {
            Perso_5 = ScriptAliases.Func_GenerateObject(typeof(AGO2000), ScriptAliases.GetPerso("StdCamer").Position());
            if (Perso_5 != null) {
                await Macro_1();
                ((AGO2000)(Perso_5)).Perso_4 = Perso_3;
                ((AGO2000)(Perso_5)).Int_5_TextLayer = Int_15;
                ((AGO2000)(Perso_5)).Int_0_X = 1000;
                ((AGO2000)(Perso_5)).Int_1_Y = ScriptAliases.Func_RandomInt(300, 640);
                ((AGO2000)(Perso_5)).Int_2 = 2;
                ((AGO2000)(Perso_5)).Int_8_XSpeed = ScriptAliases.Func_RandomInt(-7, -4);
                ((AGO2000)(Perso_5)).Int_9_YSpeed = ScriptAliases.Func_RandomInt(-2, 2);
                ((AGO2000)(Perso_5)).Int_21 = 1;
            }

        }

        private async Task Macro_18()
        {
            Perso_5 = ScriptAliases.Func_GenerateObject(typeof(AGO2000), ScriptAliases.GetPerso("StdCamer").Position());
            if (Perso_5 != null) {
                await Macro_1();
                ((AGO2000)(Perso_5)).Perso_4 = Perso_3;
                ((AGO2000)(Perso_5)).Int_5_TextLayer = Int_15;
                ((AGO2000)(Perso_5)).Int_0_X = 1000;
                ((AGO2000)(Perso_5)).Int_1_Y = (1000 - 100);
                ((AGO2000)(Perso_5)).Int_8_XSpeed = -3;
                ((AGO2000)(Perso_5)).Int_2 = 6;
                ((AGO2000)(Perso_5)).Int_21 = 5;
                ((AGO2000)(Perso_5)).Int_19 = 2;
                ((AGO2000)(Perso_5)).Int_17 = 0;
            }

        }

        #endregion

    }

}