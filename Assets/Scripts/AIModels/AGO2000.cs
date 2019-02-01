using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Menezis;

namespace Menezis.AIModels
{
    public class AGO2000 : Perso {
        public int Int_0_X = 200;
        public int Int_1_Y = 200;
        public int Int_2 = 0;
        public int Int_3 = 0;
        public Perso Perso_4;
        public int Int_5_TextLayer = 10;
        public Perso Perso_6;
        public int Int_7_ScoreValue = 0;
        public int Int_8_XSpeed = 0;
        public int Int_9_YSpeed = 0;
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
        public int Int_23_Size = 0;
        public int Int_24 = 0;
        public int Int_25 = 0;
        public int Int_26 = 0;

        protected override void Start()
        {
            base.Start();

            smRule.SetState(Rule_0_MIC_ship_init);
            smReflex.SetState(Reflex_0_MIC_ref_vide);
        }

        private async Task Rule_0_MIC_ship_init()
        {
            // Script 0
            Int_26 = 1;
            Int_16 = 255;
            Int_21 += ((JFF2000)(Perso_4)).Int_32;
            if (Int_2 == 0) {
                smRule.SetState(Rule_3_MIC_dec_go);
            } else {
                if (Int_2 == 1) {
                    smRule.SetState(Rule_1_MIC_tir_go);
                } else {
                    if (Int_2 == 2) {
                        this.Func_GetTime();
                        Int_10 = this.Func_GetTime();
                        Int_11 = (800 - (4 * ((JFF2000)(Perso_4)).Int_30));
                        Int_22 = 0;
                        Int_23_Size = 30;
                        smRule.SetState(Rule_2_MIC_en1_go);
                    } else {
                        if (Int_2 == 3) {
                            Int_10 = this.Func_GetTime();
                            smRule.SetState(Rule_4_MIC_bul_enn_go);
                        } else {
                            if (Int_2 == 4) {
                                Int_17 = 0;
                                Int_10 = this.Func_GetTime();
                                Int_23_Size = 30;
                                Int_22 = 0;
                                smRule.SetState(Rule_6_MIC_en4_go);
                            } else {
                                if (Int_2 == 5) {
                                    Int_10 = this.Func_GetTime();
                                    Int_18 = 180;
                                    Int_19 = 0;
                                    Int_22 = 1;
                                    Int_23_Size = 40;
                                    smRule.SetState(Rule_7_MIC_en5_go);
                                } else {
                                    if (Int_2 == 6) {
                                        Int_10 = this.Func_GetTime();
                                        Int_18 = Int_1_Y;
                                        Int_23_Size = 50;
                                        Int_22 = 2;
                                        smRule.SetState(Rule_8_MIC_en6_go);
                                    } else {
                                        if (Int_2 == 7) {
                                            Int_10 = this.Func_GetTime();
                                            Int_18 = 0;
                                            Int_0_X += Int_23_Size;
                                            Int_1_Y += Int_23_Size;
                                            Int_18 = Int_23_Size;
                                            smRule.SetState(Rule_9_MIC_flash);
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
                Int_23_Size = 30;
                Int_10 = this.Func_GetTime();
                smRule.SetState(Rule_10_DS1_power_up);
            } else {
                if (Int_2 == 9) {
                    Int_23_Size = 30;
                    Int_22 = 2;
                    smRule.SetState(Rule_11_DS1_en9_go);
                }
            }

            
        }

        private async Task Rule_1_MIC_tir_go()
        {
            // Script 0
            Int_0_X += (17 * Int_26);
            if (Int_0_X > 1000 || this.Cond_IsCustomBitSet(28)) {
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
                await Macro_8();
            } else {
                this.fn_p_stJFFTXTProcedure(Int_5_TextLayer, new Vector3(Int_0_X, Int_1_Y, 30), "/o600:.", 255);
            }

            
        }

        private async Task Rule_2_MIC_en1_go()
        {
            // Script 0
            Int_0_X += (Int_8_XSpeed * Int_26);
            Int_1_Y += (Int_9_YSpeed * Int_26);
            if (globalRandomizer % 4 == 0 && (Int_0_X < -200)) {
                await Macro_8();
            }

            // Script 1
            await Macro_7();
            await Macro_12();
            if (globalRandomizer % 4 == 0 && (this.Cond_IsTimeElapsed(Int_10, Int_11))) {
                Int_10 = this.Func_GetTime();
                Int_25 = 10;
                await Macro_9();
            }

            // Script 2
            Int_7_ScoreValue = 3;
            await Macro_6();

            
        }

        private async Task Rule_3_MIC_dec_go()
        {
            // Script 0
            Int_0_X -= (4 * Int_26);
            if (Int_0_X < -162) {
                Int_0_X += 162;
            }

            // Script 1
            this.fn_p_stJFFTXTProcedure(Int_5_TextLayer, new Vector3(Int_0_X, Int_1_Y, 80), "/o600:xxxxxxxx", 255);

            
        }

        private async Task Rule_4_MIC_bul_enn_go()
        {
            // Script 0
            if (Int_17 != 0) {
                Vector_14 = this.Func_Normalize(new Vector3(((JFF2000)(Perso_4)).Int_0, ((JFF2000)(Perso_4)).Int_1, 0) - new Vector3(Int_0_X, Int_1_Y, 0));
                Vector_12 = this.VEC_TemporalVectorCombination(Vector_14, 0.1f, this.Func_Normalize(new Vector3(Int_8_XSpeed, Int_9_YSpeed, 0)));
                Int_8_XSpeed = this.Func_Int((Vector_12.x * 15));
                Int_9_YSpeed = this.Func_Int((Vector_12.y * 15));
            }

            // Script 1
            Int_0_X += (Int_8_XSpeed * Int_26);
            Int_1_Y += (Int_9_YSpeed * Int_26);
            if (Boolean_15) {
                this.fn_p_stJFFTXTProcedure(Int_5_TextLayer, new Vector3(Int_0_X, Int_1_Y, 30), "/o200:.", 255);
                Boolean_15 = false;
            } else {
                this.fn_p_stJFFTXTProcedure(Int_5_TextLayer, new Vector3(Int_0_X, Int_1_Y, 30), "/o400:.", 255);
                Boolean_15 = true;
            }

            // Script 2
            await Macro_2();
            if (globalRandomizer % 2 == 0 && (!(Perso_4.Cond_IsCustomBitSet(29)))) {
                if (this.VEC_GetVectorNorm(new Vector3((((JFF2000)(Perso_4)).Int_0 + ((JFF2000)(Perso_4)).Int_19), (((JFF2000)(Perso_4)).Int_1 + ((JFF2000)(Perso_4)).Int_19), 0) - new Vector3((Int_0_X + 30), (Int_1_Y + 55), 0)) < ((10 + ((JFF2000)(Perso_4)).Int_19) * 0.8)) {
                    Perso_4.Proc_ChangeOneCustomBit(28, true);
                    await Macro_8();
                }
            }

            // Script 3
            if (globalRandomizer % 8 == 0 && (this.Cond_IsTimeElapsed(Int_10, 2500))) {
                await Macro_8();
            }

            
        }

        private async Task Rule_5_MIC_en1_paf()
        {
            // Script 0
            Int_0_X += (3 * Int_26);
            Int_1_Y += (Int_9_YSpeed * Int_26);
            if (globalRandomizer % 4 == 0 && (Int_0_X < -200 || Int_1_Y > 1000 || Int_16 < 15)) {
                await Macro_8();
            } else {
                if (Boolean_15) {
                    Int_24 = 0;
                    await Macro_7();
                    Boolean_15 = false;
                } else {
                    Int_24 = 1;
                    await Macro_7();
                    Boolean_15 = true;
                }
            }

            // Script 1
            Int_9_YSpeed += Int_26;
            if (Int_16 > 6) {
                Int_16 -= 6;
            }

            
        }

        private async Task Rule_6_MIC_en4_go()
        {
            // Script 0
            if (Int_17 == 0) {
                Int_0_X += (Int_8_XSpeed * Int_26);
                Int_1_Y += (Int_9_YSpeed * Int_26);
                if (Int_9_YSpeed > 0) {
                    Int_9_YSpeed += Int_26;
                    if (Int_1_Y >= ((JFF2000)(Perso_4)).Int_1) {
                        Int_17 += 1;
                    }
                } else {
                    Int_9_YSpeed -= Int_26;
                    if (Int_1_Y <= ((JFF2000)(Perso_4)).Int_1) {
                        Int_17 += 1;
                    }
                }
                if (Int_17 == 1) {
                    if (((JFF2000)(Perso_4)).Int_23 <= 26) {
                        Perso_6 = this.Func_GenerateObject(GetType(), this.GetPerso("StdCamer").Position());
                        if (Perso_6 != null) {
                            await Macro_4();
                            ((AGO2000)(Perso_6)).Perso_4 = Perso_4;
                            ((AGO2000)(Perso_6)).Int_5_TextLayer = Int_13;
                            ((AGO2000)(Perso_6)).Int_0_X = Int_0_X;
                            ((AGO2000)(Perso_6)).Int_1_Y = Int_1_Y;
                            ((AGO2000)(Perso_6)).Int_8_XSpeed = (-8 - ((JFF2000)(Perso_4)).Int_31);
                            ((AGO2000)(Perso_6)).Int_9_YSpeed = 0;
                            ((AGO2000)(Perso_6)).Int_2 = 3;
                            //this.GetPerso("StdCamer").SOUND_SendSoundRequest(SoundEvent(122947080));
                            //this.GetPerso("StdCamer").SOUND_SetVolumeAnim(30);
                        }
                    }
                }
            } else {
                Int_0_X += (Int_8_XSpeed * Int_26);
                if (Int_8_XSpeed >= -(15 + ((JFF2000)(Perso_4)).Int_31)) {
                    Int_8_XSpeed -= Int_26;
                }
                Int_1_Y += (Int_9_YSpeed * Int_26);
                if (Int_9_YSpeed > 0) {
                    if (Int_9_YSpeed <= 2) {
                        Int_9_YSpeed = 0;
                    } else {
                        Int_9_YSpeed -= 3;
                    }
                } else {
                    if (Int_9_YSpeed >= -2) {
                        Int_9_YSpeed = 0;
                    } else {
                        Int_9_YSpeed += 3;
                    }
                }
            }

            // Script 1
            if (Int_0_X < -200) {
                await Macro_8();
            } else {
                await Macro_7();
            }

            // Script 2
            await Macro_12();
            Int_7_ScoreValue = 5;
            await Macro_6();

            
        }

        private async Task Rule_7_MIC_en5_go()
        {
            // Script 0
            Int_0_X += (Int_8_XSpeed * Int_26);
            Int_1_Y += (Int_9_YSpeed * Int_26);
            if (Int_0_X < -200) {
                await Macro_8();
            } else {
                await Macro_7();
            }

            // Script 1
            if (Int_17 == 0) {
                if (this.Cond_IsTimeElapsed(Int_10, Int_11)) {
                    if (this.Cond_IsTimeElapsed(Int_10, (4000 + Int_11))) {
                        Int_17 += 1;
                        Int_8_XSpeed = -2;
                    } else {
                        Int_8_XSpeed = 0;
                        Int_9_YSpeed = 0;
                        if (this.Cond_IsTimeElapsed(Int_19, 100)) {
                            Int_25 = 10;
                            await Macro_11();
                            Int_18 += Int_20;
                            Int_19 = this.Func_GetTime();
                        }
                    }
                }
            } else {
                if (this.Cond_IsTimeElapsed(Int_19, 100)) {
                    Int_25 = 10;
                    await Macro_11();
                    Int_18 += Int_20;
                    Int_19 = this.Func_GetTime();
                }
            }

            // Script 2
            Int_7_ScoreValue = 15;
            await Macro_6();

            
        }

        private async Task Rule_8_MIC_en6_go()
        {
            // Script 0
            Int_0_X += (Int_8_XSpeed * Int_26);
            Int_1_Y += (Int_9_YSpeed * Int_26);
            if (Int_17 == 0) {
                Int_9_YSpeed += Int_26;
                if (Int_1_Y >= Int_18) {
                    Int_9_YSpeed = -15;
                    Int_1_Y = Int_18;
                }
            } else {
                Int_9_YSpeed -= Int_26;
                if (Int_1_Y <= Int_18) {
                    Int_9_YSpeed = 15;
                    Int_1_Y = Int_18;
                }
            }

            // Script 1
            if (Int_0_X < -100 || Int_0_X > 1000) {
                if (Int_19 == 0) {
                    await Macro_8();
                } else {
                    Int_8_XSpeed = -Int_8_XSpeed;
                    Int_19 -= 1;
                }
            }

            // Script 2
            await Macro_7();
            await Macro_12();
            if (this.Cond_IsTimeElapsed(Int_10, Int_11)) {
                Int_10 = this.Func_GetTime();
                Int_11 = (this.Func_RandomInt(3000, 5000) - (10 * ((JFF2000)(Perso_4)).Int_30));
                Int_25 = 10;
                await Macro_10();
            }

            // Script 3
            Int_7_ScoreValue = 10;
            await Macro_6();

            
        }

        private async Task Rule_9_MIC_flash()
        {
            // Script 0
            if (!(Int_19!=0)) { // unsure
                Int_18 += (int)((5 * this.Func_GetDeltaTime()) / 16);
            } else {
                Int_18 += (int)((5 * this.Func_GetDeltaTime()) / 32);
            }

            // Script 1
            if (((Int_18 * 4) - Int_23_Size) > 255) {
                await Macro_8();
            } else {
                if (Int_22 == 0) {
                    this.fn_p_stJFFTXTProcedure(Int_5_TextLayer, new Vector3((Int_0_X - Int_18), (Int_1_Y - Int_18), Int_18), "/o600:x", (byte)((255 + Int_23_Size) - (Int_18 * 4)));
                } else {
                    if (Int_22 == 1) {
                        this.fn_p_stJFFTXTProcedure(Int_5_TextLayer, new Vector3((Int_0_X - Int_18), (Int_1_Y - Int_18), Int_18), "/o600:o", (byte)((255 + Int_23_Size) - (Int_18 * 4)));
                    } else {
                        this.fn_p_stJFFTXTProcedure(Int_5_TextLayer, new Vector3((Int_0_X - Int_18), (Int_1_Y - Int_18), Int_18), "/o600:e", (byte)((255 + Int_23_Size) - (Int_18 * 4)));
                    }
                }
            }

            
        }

        private async Task Rule_10_DS1_power_up()
        {
            // Script 0
            Int_18 += (8 * Int_26);
            Int_19 += Int_26;
            Int_8_XSpeed = this.Func_Int((this.Func_Sinus(Int_18) * (15 + (40 * this.Func_Sinus(Int_19)))));
            Int_9_YSpeed = this.Func_Int((this.Func_Cosinus(Int_18) * (15 + (40 * this.Func_Sinus(Int_19)))));
            if (this.Cond_IsTimeElapsed(Int_10, 8000)) {
                if (this.Cond_IsTimeElapsed(Int_10, (8000 + 4000))) {
                    await Macro_8();
                } else {
                    Int_20 = (this.Func_RandomInt(201, 255) - (((this.Func_GetTime() - Int_10) - 8000) / 20));
                }
            } else {
                Int_20 += (6 * Int_26);
                if (Int_20 > 255) {
                    Int_20 -= 200;
                }
            }

            // Script 1
            if (this.VEC_GetVectorNorm(new Vector3((((JFF2000)(Perso_4)).Int_0 + ((JFF2000)(Perso_4)).Int_19), (((JFF2000)(Perso_4)).Int_1 + ((JFF2000)(Perso_4)).Int_19), 0) - new Vector3((Int_0_X + Int_23_Size), (Int_1_Y + Int_23_Size), 0)) < (((JFF2000)(Perso_4)).Int_19 + Int_23_Size)) {
                ((JFF2000)(Perso_4)).Int_22_Jumps += 1;
                //this.GetPerso("StdCamer").SOUND_SendSoundRequest(SoundEvent(122577408));
                //this.GetPerso("StdCamer").SOUND_SetVolumeAnim(120);
                await Macro_8();
            }

            // Script 2
            this.fn_p_stJFFTXTProcedure(Int_5_TextLayer, new Vector3((Int_0_X + Int_8_XSpeed), (Int_1_Y + Int_9_YSpeed), Int_23_Size), "/o400:!", (byte)Int_20);

            
        }

        private async Task Rule_11_DS1_en9_go()
        {
            // Script 0
            if (Int_17 == 0) {
                if (!(Int_0_X > 15)) {
                    Int_0_X += Int_26;
                } else {
                    Int_17 += 1;
                    Int_10 = this.Func_GetTime();
                    Int_20 = 7;
                }
            } else {
                if (Int_17 == 2) {
                    if (!(Int_0_X < (-Int_23_Size - Int_23_Size))) {
                        Int_0_X -= Int_26;
                    } else {
                        await Macro_8();
                    }
                } else {
                    if (this.Cond_IsTimeElapsed(Int_10, (1500 - (5 * ((JFF2000)(Perso_4)).Int_30)))) {
                        Int_25 = (6 + this.Func_RandomInt(0, 4));
                        Vector_12 = this.Func_Normalize(new Vector3(((JFF2000)(Perso_4)).Int_0, ((JFF2000)(Perso_4)).Int_1, 0) - new Vector3(Int_0_X, Int_1_Y, 0));
                        Int_19 = -this.Func_Int(this.VEC_AngleVector(new Vector3(1, 0, 0), Vector_12, 0));
                        Int_25 = (6 + this.Func_RandomInt(0, 4));
                        Int_18 = (Int_19 - 18);
                        await Macro_11();
                        await this.TIME_FrozenWait(1);
                        Int_25 = (6 + this.Func_RandomInt(0, 4));
                        Int_18 = (Int_19 - 12);
                        await Macro_11();
                        await this.TIME_FrozenWait(1);
                        Int_18 = (Int_19 - 6);
                        Int_25 = (6 + this.Func_RandomInt(0, 4));
                        await Macro_11();
                        await this.TIME_FrozenWait(1);
                        Int_18 = Int_19;
                        Int_25 = (6 + this.Func_RandomInt(0, 4));
                        await Macro_11();
                        await this.TIME_FrozenWait(1);
                        Int_18 = (Int_19 + 6);
                        Int_25 = (6 + this.Func_RandomInt(0, 4));
                        await Macro_11();
                        await this.TIME_FrozenWait(1);
                        Int_18 = (Int_19 + 12);
                        Int_25 = (6 + this.Func_RandomInt(0, 4));
                        await Macro_11();
                        Int_18 = (Int_19 + 18);
                        Int_25 = (6 + this.Func_RandomInt(0, 4));
                        await Macro_11();
                        Int_10 = this.Func_GetTime();
                        if (Int_20 == 1) {
                            Int_17 += 1;
                        } else {
                            Int_20 -= 1;
                        }
                    }
                }
            }

            // Script 1
            await Macro_7();
            await Macro_15();

            
        }

        private async Task Reflex_0_MIC_ref_vide()
        {
            // Script 0
            Int_26 = this.Func_Int((this.Func_GetDeltaTime() * 0.0625f));
            if (Perso_4.Cond_IsCustomBitSet(30)) {
                await Macro_8();
            }

            
        }

        private async Task Macro_0()
        {
            if (this.VEC_GetVectorNorm(new Vector3((((AGO2000)(Perso_6)).Int_0_X + 30), (((AGO2000)(Perso_6)).Int_1_Y + 54), 0) - new Vector3((Int_0_X + Int_23_Size), (Int_1_Y + Int_23_Size), 0)) < ((Int_23_Size + ((AGO2000)(Perso_6)).Int_23_Size) * 1.5)) {
                this.Proc_ChangeOneCustomBit(29, true);
                Perso_6.Proc_ChangeOneCustomBit(28, true);
                if (!(Int_21!=0)) {
                    //this.GetPerso("StdCamer").SOUND_SendSoundRequest(SoundEvent(122806064));
                    //this.GetPerso("StdCamer").SOUND_SetVolumeAnim(120);
                    if (Perso_4.Cond_IsCustomBitSet(31)) {
                        await Macro_13();
                    }
                    await Macro_1();
                    Int_9_YSpeed = -20;
                    Int_16 = 255;
                    smRule.SetState(Rule_5_MIC_en1_paf);
                } else {
                    Int_7_ScoreValue = 1;
                    await Macro_1();
                    await Macro_14();
                    Int_21 -= 1;
                    //SOUND_SendSoundRequest(SoundEvent(122758312));
                    //SOUND_SetVolumeAnim(120);
                }
            }

             ;
        }

        private async Task Macro_1()
        {
            ((JFF2000)(Perso_4)).Int_13_Score += Int_7_ScoreValue;

            
        }

        private async Task Macro_2()
        {
            if (globalRandomizer % 4 == 0 && (true)) {
                if (Int_0_X > 1000) {
                    await Macro_8();
                } else {
                    if (Int_0_X < (2 * -Int_23_Size)) {
                        await Macro_8();
                    }
                }
                if (Int_1_Y > 1000) {
                    await Macro_8();
                } else {
                    if (Int_1_Y < (2 * -Int_23_Size)) {
                        await Macro_8();
                    }
                }
            }

            
        }

        private async Task Macro_4()
        {
            Int_13 = ((JFF2000)(Perso_4)).Int_4;
            for (int i = 0; i < 50; i++) {

                if (this.GetPerso<World>("World").IntegerArray_25[Int_13] == 0) {
                    ((JFF2000)(Perso_4)).Int_4 = Int_13;
                    this.GetPerso<World>("World").IntegerArray_25[Int_13] = 1;
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

            
        }

        private async Task Macro_5()
        {
            this.GetPerso<World>("World").IntegerArray_25[Int_5_TextLayer] = 0;
            ((JFF2000)(Perso_4)).Int_23 -= 1;

            
        }

        private async Task Macro_6()
        {
            if (((JFF2000)(Perso_4)).Boolean_10) {
                Perso_6 = ((JFF2000)(Perso_4)).Perso_7;
                await Macro_0();
            }
            if (!(this.Cond_IsCustomBitSet(29)) && ((JFF2000)(Perso_4)).Boolean_11) {
                Perso_6 = ((JFF2000)(Perso_4)).Perso_8;
                await Macro_0();
            }
            if (!(this.Cond_IsCustomBitSet(29)) && ((JFF2000)(Perso_4)).Boolean_12) {
                Perso_6 = ((JFF2000)(Perso_4)).Perso_9;
                await Macro_0();
            }
            this.Proc_ChangeOneCustomBit(29, false);

            
        }

        private async Task Macro_7()
        {
            if (Int_22 == 0) {
                if (Int_24 == 0) {
                    this.fn_p_stJFFTXTProcedure(Int_5_TextLayer, new Vector3(Int_0_X, Int_1_Y, Int_23_Size), "/o200:x", (byte)Int_16);
                } else {
                    this.fn_p_stJFFTXTProcedure(Int_5_TextLayer, new Vector3(Int_0_X, Int_1_Y, Int_23_Size), "/o600:x", (byte)Int_16);
                }
            } else {
                if (Int_22 == 1) {
                    if (Int_24 == 0) {
                        this.fn_p_stJFFTXTProcedure(Int_5_TextLayer, new Vector3(Int_0_X, Int_1_Y, Int_23_Size), "/o200:0", (byte)Int_16);
                    } else {
                        this.fn_p_stJFFTXTProcedure(Int_5_TextLayer, new Vector3(Int_0_X, Int_1_Y, Int_23_Size), "/o600:0", (byte)Int_16);
                    }
                } else {
                    if (Int_22 == 2) {
                        this.fn_p_stJFFTXTProcedure(Int_5_TextLayer, new Vector3(Int_0_X, Int_1_Y, Int_23_Size), "/o200:8", (byte)Int_16);
                    }
                }
            }

            
        }

        private async Task Macro_8()
        {
            this.fn_p_stJFFTXTProcedure(Int_5_TextLayer, new Vector3(0, 0, 0), "/o200:x", 0);
            await Macro_5();
            this.fn_p_stKillPersoAndClearVariableProcedure1(this);

            
        }

        private async Task Macro_9()
        {
            if (((JFF2000)(Perso_4)).Int_23 < 25) {
                Perso_6 = this.Func_GenerateObject(GetType(), this.GetPerso("StdCamer").Position());
                if (Perso_6 != null) {
                    Vector_12 = this.Func_Normalize(new Vector3(((JFF2000)(Perso_4)).Int_0, ((JFF2000)(Perso_4)).Int_1, 0) - new Vector3(Int_0_X, Int_1_Y, 0));
                    await Macro_4();
                    ((AGO2000)(Perso_6)).Perso_4 = Perso_4;
                    ((AGO2000)(Perso_6)).Int_5_TextLayer = Int_13;
                    ((AGO2000)(Perso_6)).Int_0_X = Int_0_X;
                    ((AGO2000)(Perso_6)).Int_1_Y = Int_1_Y;
                    ((AGO2000)(Perso_6)).Int_8_XSpeed = this.Func_Int((Vector_12.x * (Int_25 + ((JFF2000)(Perso_4)).Int_31)));
                    ((AGO2000)(Perso_6)).Int_9_YSpeed = this.Func_Int((Vector_12.y * (Int_25 + ((JFF2000)(Perso_4)).Int_31)));
                    ((AGO2000)(Perso_6)).Int_2 = 3;
                    ((AGO2000)(Perso_6)).Int_17 = 0;
                    //SOUND_SendSoundRequest(SoundEvent(122465704));
                    //SOUND_SetVolumeAnim(60);
                }
            }

            
        }

        private async Task Macro_10()
        {
            if (((JFF2000)(Perso_4)).Int_23 < 25) {
                Perso_6 = this.Func_GenerateObject(GetType(), this.GetPerso("StdCamer").Position());
                if (Perso_6 != null) {
                    Vector_12 = this.Func_Normalize(new Vector3(((JFF2000)(Perso_4)).Int_0, ((JFF2000)(Perso_4)).Int_1, 0) - new Vector3(Int_0_X, Int_1_Y, 0));
                    await Macro_4();
                    ((AGO2000)(Perso_6)).Perso_4 = Perso_4;
                    ((AGO2000)(Perso_6)).Int_5_TextLayer = Int_13;
                    ((AGO2000)(Perso_6)).Int_0_X = Int_0_X;
                    ((AGO2000)(Perso_6)).Int_1_Y = Int_1_Y;
                    ((AGO2000)(Perso_6)).Int_8_XSpeed = this.Func_Int((Vector_12.x * (Int_25 + ((JFF2000)(Perso_4)).Int_31)));
                    ((AGO2000)(Perso_6)).Int_9_YSpeed = this.Func_Int((Vector_12.y * (Int_25 + ((JFF2000)(Perso_4)).Int_31)));
                    ((AGO2000)(Perso_6)).Int_2 = 3;
                    ((AGO2000)(Perso_6)).Int_17 = 1;
                    //SOUND_SendSoundRequest(SoundEvent(123169304));
                    //SOUND_SetVolumeAnim(60);
                }
            }

            
        }

        private async Task Macro_11()
        {
            if (((JFF2000)(Perso_4)).Int_23 < 25) {
                Perso_6 = this.Func_GenerateObject(GetType(), this.GetPerso("StdCamer").Position());
                if (Perso_6 != null) {
                    await Macro_4();
                    ((AGO2000)(Perso_6)).Perso_4 = Perso_4;
                    ((AGO2000)(Perso_6)).Int_5_TextLayer = Int_13;
                    ((AGO2000)(Perso_6)).Int_0_X = (Int_0_X + 13);
                    ((AGO2000)(Perso_6)).Int_1_Y = (Int_1_Y - 15);
                    ((AGO2000)(Perso_6)).Int_8_XSpeed = this.Func_Int((this.Func_Cosinus(Int_18) * (Int_25 + ((JFF2000)(Perso_4)).Int_31)));
                    ((AGO2000)(Perso_6)).Int_9_YSpeed = -this.Func_Int((this.Func_Sinus(Int_18) * (Int_25 + ((JFF2000)(Perso_4)).Int_31)));
                    ((AGO2000)(Perso_6)).Int_2 = 3;
                    //SOUND_SendSoundRequest(SoundEvent(122465704));
                    //SOUND_SetVolumeAnim(60);
                }
            }

            
        }

        private async Task Macro_12()
        {
            if (globalRandomizer % 2 == 0 && (!(Perso_4.Cond_IsCustomBitSet(29)))) {
                if (this.VEC_GetVectorNorm(new Vector3((((JFF2000)(Perso_4)).Int_0 + 30), (((JFF2000)(Perso_4)).Int_1 + 30), 0) - new Vector3((Int_0_X + 40), (Int_1_Y + 40), 0)) < 70) {
                    Perso_4.Proc_ChangeOneCustomBit(28, true);
                    Int_9_YSpeed = -20;
                    Int_16 = 255;
                    //SOUND_SendSoundRequest(SoundEvent(122806064));
                    //SOUND_SetVolumeAnim(60);
                    smRule.SetState(Rule_5_MIC_en1_paf);
                }
            }

            
        }

        private async Task Macro_13()
        {
            if (((JFF2000)(Perso_4)).Int_23 < 25) {
                Perso_6 = this.Func_GenerateObject(GetType(), this.GetPerso("StdCamer").Position());
                if (Perso_6 != null) {
                    await Macro_4();
                    ((AGO2000)(Perso_6)).Perso_4 = Perso_4;
                    ((AGO2000)(Perso_6)).Int_5_TextLayer = Int_13;
                    ((AGO2000)(Perso_6)).Int_0_X = Int_0_X;
                    ((AGO2000)(Perso_6)).Int_1_Y = Int_1_Y;
                    ((AGO2000)(Perso_6)).Int_2 = 8;
                    Perso_4.Proc_ChangeOneCustomBit(31, false);
                }
            }

            
        }

        private async Task Macro_14()
        {
            if (((JFF2000)(Perso_4)).Int_23 < 25) {
                Perso_6 = this.Func_GenerateObject(GetType(), this.GetPerso("StdCamer").Position());
                if (Perso_6!=null) {
                    await Macro_4();
                    ((AGO2000)(Perso_6)).Perso_4 = Perso_4;
                    ((AGO2000)(Perso_6)).Int_5_TextLayer = Int_13;
                    ((AGO2000)(Perso_6)).Int_0_X = Int_0_X;
                    ((AGO2000)(Perso_6)).Int_1_Y = Int_1_Y;
                    ((AGO2000)(Perso_6)).Int_2 = 7;
                    ((AGO2000)(Perso_6)).Int_22 = Int_22;
                    ((AGO2000)(Perso_6)).Int_23_Size = Int_23_Size;
                }
            }

            
        }

        private async Task Macro_15()
        {
            if (globalRandomizer % 2 == 0 && (!(Perso_4.Cond_IsCustomBitSet(29)))) {
                if (this.VEC_GetVectorNorm(new Vector3((((JFF2000)(Perso_4)).Int_0 + 30), (((JFF2000)(Perso_4)).Int_1 + 30), 0) - new Vector3((Int_0_X + 40), (Int_1_Y + 40), 0)) < 70) {
                    Perso_4.Proc_ChangeOneCustomBit(28, true);
                }
            }

            
        }
    }
}
