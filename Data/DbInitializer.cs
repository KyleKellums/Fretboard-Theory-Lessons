using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Fretboard_Theory_Course.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Fretboard_Theory_Course.Data
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                var userstore = new UserStore<ApplicationUser>(context);

                if (!context.Roles.Any(r => r.Name == "Administrator"))

                if (!context.ApplicationUser.Any(u => u.FirstName == "admin"))
                {
                    //  This method will be called after migrating to the latest version.
                    ApplicationUser user = new ApplicationUser {
                        FirstName = "admin",
                        LastName = "admin",
                        StreetAddress = "123 Infinity Way",
                        UserName = "admin@admin.com",
                        NormalizedUserName = "ADMIN@ADMIN.COM",
                        Email = "admin@admin.com",
                        NormalizedEmail = "ADMIN@ADMIN.COM",
                        EmailConfirmed = true,
                        LockoutEnabled = false,
                        SecurityStamp = Guid.NewGuid().ToString("D")
                    };
                    var passwordHash = new PasswordHasher<ApplicationUser>();
                    user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
                    await userstore.CreateAsync(user);
                    await userstore.AddToRoleAsync(user, "Administrator");

                }

                // Seed Data for Foundations.
                if (context.Foundations.Any())
                {
                    return;   // DB has been seeded
                }

                var foundations = new Foundations[]
                {
                    new Foundations { 
                        LessonName = "Fretboard",
                        Images = new List<string>() {"../wwwroot/images/1-Foundations/Fretboard/Natural_Notes_B&W.png",
                        "../wwwroot/images/1-Foundations/Fretboard/Natural_Notes_Colored.png",
                        "../wwwroot/images/1-Foundations/Fretboard/Natural_Notes_Horizontal.png",
                        "../wwwroot/images/1-Foundations/Fretboard/TwoCharts_Vertical.jpg"}
                    },
                    new Foundations { 
                        LessonName = "KeySignatures",
                        Images = new List<string>()
                        { 
                            "../wwwroot/images/1-Foundations/KeySignatures/key_signature_chart.png",
                            "../wwwroot/images/1-Foundations/KeySignatures/key_signatures_notation.png",
                            "../wwwroot/images/1-Foundations/KeySignatures/key_signatures_staff.png"
                        }
                    },
                    new Foundations { 
                        LessonName = "MajorMinorScales",
                        Images = new List<string>()
                        {
                            "../wwwroot/images/1-Foundations/MajorMinorScales/C_ScaleOnOneString.png",
                            "../wwwroot/images/1-Foundations/MajorMinorScales/C_ScaleWithOpenStrings.png",
                            "../wwwroot/images/1-Foundations/MajorMinorScales/C_ScaleWithNotation.png",
                            "../wwwroot/images/1-Foundations/MajorMinorScales/MajorScalePattern.png",
                            "../wwwroot/images/1-Foundations/MajorMinorScales/RelativeMinor_C.png",
                            "../wwwroot/images/1-Foundations/MajorMinorScales/A_MinorScaleOpenStrings.jpeg",
                            "../wwwroot/images/1-Foundations/MajorMinorScales/GMajorPattern.png",
                            "../wwwroot/images/1-Foundations/MajorMinorScales/G_MinorScale.png",
                            "../wwwroot/images/1-Foundations/MajorMinorScales/E_MinorScaleOpenStrings.png",
                            "../wwwroot/images/1-Foundations/MajorMinorScales/C_MinorYellowDiagram.png"
                        } 
                    },
                    
                    new Foundations { 
                        LessonName = "ChordBuilding",
                        Images = new List<string>() 
                        {
                            "../wwwroot/images/1-Foundations/ChordBuilding/10_C_Chord_Formulas.jpg",
                            "../wwwroot/images/1-Foundations/ChordBuilding/C_MinorTriadDiagram.png",
                            "../wwwroot/images/1-Foundations/ChordBuilding/Chord_Building_In_7_Keys.jpg",
                            "../wwwroot/images/1-Foundations/ChordBuilding/ChordBuildingOn_C_Scale.gif",
                            "../wwwroot/images/1-Foundations/ChordBuilding/ChordFormulas.jpg",
                            "../wwwroot/images/1-Foundations/ChordBuilding/ConsumateChordBuilder_Diagram.jpg",
                            "../wwwroot/images/1-Foundations/ChordBuilding/Triad_Formulas.png"
                        }
                    },
                    new Foundations { 
                        LessonName = "Modes",
                        Images = new List<string>() 
                        {
                            "../wwwroot/images/1-Foundations/Modes/Ionian.jpg",
                            "../wwwroot/images/1-Foundations/Modes/Dorian.jpg",
                            "../wwwroot/images/1-Foundations/Modes/Phrygian.jpg",
                            "../wwwroot/images/1-Foundations/Modes/Lydian.jpg",
                            "../wwwroot/images/1-Foundations/Modes/Mixolydian.jpg",
                            "../wwwroot/images/1-Foundations/Modes/Aeolian.jpg",
                            "../wwwroot/images/1-Foundations/Modes/Locrian.jpg",
                            "../wwwroot/images/1-Foundations/Modes/AllModes_Patterns.png",
                            "../wwwroot/images/1-Foundations/Modes/Mode_Connecting_Lines.jpg"
                        }
                    },
                    new Foundations { 
                        LessonName = "OtherScales",
                        Images = new List<string>() 
                        {
                            "../wwwroot/images/1-Foundations/OtherScales/5thFretPentatonicPattern.png",
                            "../wwwroot/images/1-Foundations/OtherScales/A-Melodic-Minor-Scale.png",
                            "../wwwroot/images/1-Foundations/OtherScales/Blues_Scale_Pattern.png",
                            "../wwwroot/images/1-Foundations/OtherScales/C_HarmonicMinor.png",
                            "../wwwroot/images/1-Foundations/OtherScales/C_MinorBebopAscendDescend.png"
                        }
                    }
                };

                foreach (Foundations i in foundations)
                {
                    context.Foundations.Add(i);
                }
                context.SaveChanges();


                // Seed Data for Intermediate.
                if (context.Intermediate.Any())
                {
                    return;   // DB has been seeded
                }

                var intermediate = new Intermediate[]
                {
                    new Intermediate { 
                        LessonName = "Arpeggios",
                        Images = new List<string>() {"../wwwroot/images/2-Intermediate/Arpeggios/CMinorMajor7-Arpeggio", 
                        "../wwwroot/images/2-Intermediate/Arpeggios/Gmajor7_1-2-4-5.png"
                        }
                    },
                    new Intermediate { 
                        LessonName = "Caged",
                        Images = new List<string>()
                        { 
                            "../wwwroot/images/2-Intermediate/Caged/CAGED_Shape_Shift.png",
                            "../wwwroot/images/2-Intermediate/Caged/CAGED_ColorCoded.png"
                        }
                    },
                    new Intermediate { 
                        LessonName = "Major7_Apreggios",
                        Images = new List<string>()
                        {
                            "../wwwroot/images/2-Intermediate/Major7_Apreggios/4_Note_Chords_KeyOfC.jpg.jpeg",
                            "../wwwroot/images/2-Intermediate/Major7_Apreggios/All_Arpeggios_In_C_5Strings.jpeg",
                            "../wwwroot/images/2-Intermediate/Major7_Apreggios/Key_Of_C_Arpeggios.png",
                            "../wwwroot/images/2-Intermediate/Major7_Apreggios/Key_Of_C_Arpeggios_Same_Position.jpeg"
                        } 
                    },
                    new Intermediate { 
                        LessonName = "Pentatonic",
                        Images = new List<string>() 
                        {
                            "../wwwroot/images/2-Intermediate/Pentatonic/Pentatonic_Positions_Seperate_Diagrams.png",
                            "../wwwroot/images/2-Intermediate/Pentatonic/Pentatonic_Color_Code_Positions.png",
                            "../wwwroot/images/2-Intermediate/Pentatonic/DotDiagram_5_PositionPentatonic.png",
                            "../wwwroot/images/2-Intermediate/Pentatonic/Color_Coded_Pent_Positions.jpeg",
                            "../wwwroot/images/2-Intermediate/Pentatonic/5thPosition_E_Pentatonic.png",
                            "../wwwroot/images/2-Intermediate/Pentatonic/E_Pentatonic_All_Positions.png",
                            "../wwwroot/images/2-Intermediate/Pentatonic/Pentatonic_Ascend_Through_Positions_Line.png"
                        }
                    }
                };

                foreach (Intermediate i in intermediate)
                {
                    context.Intermediate.Add(i);
                }
                context.SaveChanges();

                // Seed Data for Advanced.
                if (context.Advanced.Any())
                {
                    return;   // DB has been seeded
                }

                var advanced = new Advanced[]
                {
                    new Advanced { 
                        LessonName = "Altered_Chords",
                        Images = new List<string>() 
                        {
                            "../wwwroot/images/3-Advanced/Altered_Chords/2-5-1_Atlered5.png", 
                            "../wwwroot/images/3-Advanced/Altered_Chords/Altered_C7_chords.gif",
                            "../wwwroot/images/3-Advanced/Altered_Chords/Altered_C7chords_6.gif.gif",
                            "../wwwroot/images/3-Advanced/Altered_Chords/Altered_G7_chords.png.gif"
                        }
                    },
                    new Advanced { 
                        LessonName = "Exercises_Practice",
                        Images = new List<string>()
                        { 
                            "../wwwroot/images/3-Advanced/Exercises_Practice/Am_Sweeps.png", 
                            "../wwwroot/images/3-Advanced/Exercises_Practice/Jazzy2_5_1.png",
                            "../wwwroot/images/3-Advanced/Exercises_Practice/UpTwoDownOne_C_Scale.png"
                        }
                    },
                    new Advanced { 
                        LessonName = "JazzMinor_Over_7chords",
                        Images = new List<string>()
                        {
                            "../wwwroot/images/3-Advanced/JazzMinor_Over_7chords/2-5-1_Key_C.png", 
                            "../wwwroot/images/3-Advanced/JazzMinor_Over_7chords/2-5-1_KeyOfC.jpg",
                            "../wwwroot/images/3-Advanced/JazzMinor_Over_7chords/DomG7_1-4-5.png",
                            "../wwwroot/images/3-Advanced/JazzMinor_Over_7chords/Gdom7_jazzVoicing.png"
                        } 
                    },
                    new Advanced { 
                        LessonName = "Superimposition",
                        Images = new List<string>() 
                        {
                            "../wwwroot/images/3-Advanced/Superimposition/2-5-1_with_B_Over_D7.png", 
                            "../wwwroot/images/3-Advanced/Superimposition/Emin_Pentatonic_Over_Am7_Chord.png",
                            "../wwwroot/images/3-Advanced/Superimposition/triad_superimposition_2-5-1.png",
                            "../wwwroot/images/3-Advanced/Superimposition/Triad_Superimposition_B_Over_D7.png"
                        }
                    },
                    new Advanced { 
                        LessonName = "UpperPartials",
                        Images = new List<string>() 
                        {
                            "../wwwroot/images/3-Advanced/UpperPartials/2_OctaveChartForUpperPartials.png", 
                            "../wwwroot/images/3-Advanced/UpperPartials/Chord_Extentions_Key_C.png"
                        }
                    }
                };

                foreach (Advanced i in advanced)
                {
                    context.Advanced.Add(i);
                }
                context.SaveChanges();

                // Seed Data for Resources.
                if (context.Resources.Any())
                {
                    return;   // DB has been seeded
                }

                var resources = new Resources[]
                {
                    new Resources { 
                        ResourceType = "Templates",
                        Images = new List<string>() 
                        {
                            "../wwwroot/images/Resources/Templates/12_fret_template.png", 
                            "../wwwroot/images/Resources/Templates/15_fret_diagrams.pdf", 
                            "../wwwroot/images/Resources/Templates/16_fret_template.png", 
                            "../wwwroot/images/Resources/Templates/23_fret_template.jpg", 
                            "../wwwroot/images/Resources/Templates/chord_diagram_templates.png", 
                            "../wwwroot/images/Resources/Templates/fretboard_19frets.png" 
                        }
                    }
                };

                foreach (Resources i in resources)
                {
                    context.Resources.Add(i);
                }
                context.SaveChanges();
            }
       }
    }
}