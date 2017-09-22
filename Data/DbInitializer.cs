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
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                var userstore = new UserStore<ApplicationUser>(context);

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
                }

                // Seed Data for Foundations.
                if (context.Foundations.Any())
                {
                    return;   // DB has been seeded
                }

                var foundations = new Foundations_2[]
                {
                    new Foundations_2 { 
                        LessonName = "Fretboard",
                        Images = new List<string>() {"/images/1-Foundations/Fretboard/Natural_Notes_B&W.png",
                        "/images/1-Foundations/Fretboard/Natural_Notes_Colored.png",
                        "/images/1-Foundations/Fretboard/Natural_Notes_Horizontal.png",
                        "/images/1-Foundations/Fretboard/TwoCharts_Vertical.jpg"}
                    },
                    new Foundations_2 { 
                        LessonName = "KeySignatures",
                        Images = new List<string>()
                        { 
                            "/images/1-Foundations/KeySignatures/key_signature_chart.png",
                            "/images/1-Foundations/KeySignatures/key_signatures_notation.png",
                            "/images/1-Foundations/KeySignatures/key_signatures_staff.png"
                        }
                    },
                    new Foundations_2 { 
                        LessonName = "MajorMinorScales",
                        Images = new List<string>()
                        {
                            "/images/1-Foundations/MajorMinorScales/C_ScaleOnOneString.png",
                            "/images/1-Foundations/MajorMinorScales/C_ScaleWithOpenStrings.png",
                            "/images/1-Foundations/MajorMinorScales/C_ScaleWithNotation.png",
                            "/images/1-Foundations/MajorMinorScales/MajorScalePattern.png",
                            "/images/1-Foundations/MajorMinorScales/RelativeMinor_C.png",
                            "/images/1-Foundations/MajorMinorScales/A_MinorScaleOpenStrings.jpeg",
                            "/images/1-Foundations/MajorMinorScales/GMajorPattern.png",
                            "/images/1-Foundations/MajorMinorScales/G_MinorScale.png",
                            "/images/1-Foundations/MajorMinorScales/E_MinorScaleOpenStrings.png",
                            "/images/1-Foundations/MajorMinorScales/C_MinorYellowDiagram.png"
                        } 
                    },
                    
                    new Foundations_2 { 
                        LessonName = "ChordBuilding",
                        Images = new List<string>() 
                        {
                            "/images/1-Foundations/ChordBuilding/10_C_Chord_Formulas.jpg",
                            "/images/1-Foundations/ChordBuilding/C_MinorTriadDiagram.png",
                            "/images/1-Foundations/ChordBuilding/Chord_Building_In_7_Keys.jpg",
                            "/images/1-Foundations/ChordBuilding/ChordBuildingOn_C_Scale.gif",
                            "/images/1-Foundations/ChordBuilding/ChordFormulas.jpg",
                            "/images/1-Foundations/ChordBuilding/ConsumateChordBuilder_Diagram.jpg",
                            "/images/1-Foundations/ChordBuilding/Triad_Formulas.png"
                        }
                    },
                    new Foundations_2 { 
                        LessonName = "Modes",
                        Images = new List<string>() 
                        {
                            "/images/1-Foundations/Modes/Ionian.jpg",
                            "/images/1-Foundations/Modes/Dorian.jpg",
                            "/images/1-Foundations/Modes/Phrygian.jpg",
                            "/images/1-Foundations/Modes/Lydian.jpg",
                            "/images/1-Foundations/Modes/Mixolydian.jpg",
                            "/images/1-Foundations/Modes/Aeolian.jpg",
                            "/images/1-Foundations/Modes/Locrian.jpg",
                            "/images/1-Foundations/Modes/AllModes_Patterns.png",
                            "/images/1-Foundations/Modes/Mode_Connecting_Lines.jpg"
                        }
                    },
                    new Foundations_2 { 
                        LessonName = "OtherScales",
                        Images = new List<string>() 
                        {
                            "/images/1-Foundations/OtherScales/5thFretPentatonicPattern.png",
                            "/images/1-Foundations/OtherScales/A-Melodic-Minor-Scale.png",
                            "/images/1-Foundations/OtherScales/Blues_Scale_Pattern.png",
                            "/images/1-Foundations/OtherScales/C_HarmonicMinor.png",
                            "/images/1-Foundations/OtherScales/C_MinorBebopAscendDescend.png"
                        }
                    }
                };

                int foundationsLessonId = 1;
                foreach(Foundations_2 i in foundations)
                {
                    Foundations newFoundations = new Foundations()
                    {
                        LessonName = i.LessonName
                    };
                    context.Add(newFoundations);
                    Console.WriteLine("Testing XXXSXXXXXX");

                    foreach(string image in i.Images)
                    {
                        FoundationsImages newImg = new FoundationsImages()
                        {
                            Path = image,
                            FoundationsId = foundationsLessonId
                        };

                        context.Add(newImg);
                    }

                    foundationsLessonId ++;
                }

                var intermediate = new Intermediate_2[]
                {
                    new Intermediate_2 { 
                        LessonName = "Arpeggios",
                        Images = new List<string>() {"/images/2-Intermediate/Arpeggios/CMinorMajor7-Arpeggio", 
                        "/images/2-Intermediate/Arpeggios/Gmajor7_1-2-4-5.png"
                        }
                    },
                    new Intermediate_2 { 
                        LessonName = "Caged",
                        Images = new List<string>()
                        { 
                            "/images/2-Intermediate/Caged/CAGED_Shape_Shift.png",
                            "/images/2-Intermediate/Caged/CAGED_ColorCoded.png"
                        }
                    },
                    new Intermediate_2 { 
                        LessonName = "Major7_Apreggios",
                        Images = new List<string>()
                        {
                            "/images/2-Intermediate/Major7_Apreggios/4_Note_Chords_KeyOfC.jpg.jpeg",
                            "/images/2-Intermediate/Major7_Apreggios/All_Arpeggios_In_C_5Strings.jpeg",
                            "/images/2-Intermediate/Major7_Apreggios/Key_Of_C_Arpeggios.png",
                            "/images/2-Intermediate/Major7_Apreggios/Key_Of_C_Arpeggios_Same_Position.jpeg"
                        } 
                    },
                    new Intermediate_2 { 
                        LessonName = "Pentatonic",
                        Images = new List<string>() 
                        {
                            "/images/2-Intermediate/Pentatonic/Pentatonic_Positions_Seperate_Diagrams.png",
                            "/images/2-Intermediate/Pentatonic/Pentatonic_Color_Code_Positions.png",
                            "/images/2-Intermediate/Pentatonic/DotDiagram_5_PositionPentatonic.png",
                            "/images/2-Intermediate/Pentatonic/Color_Coded_Pent_Positions.jpeg",
                            "/images/2-Intermediate/Pentatonic/5thPosition_E_Pentatonic.png",
                            "/images/2-Intermediate/Pentatonic/E_Pentatonic_All_Positions.png",
                            "/images/2-Intermediate/Pentatonic/Pentatonic_Ascend_Through_Positions_Line.png"
                        }
                    }
                };

                int intermediateLessonId = 1;
                foreach(Intermediate_2 i in intermediate)
                {
                    Intermediate newIntermediate = new Intermediate()
                    {
                        LessonName = i.LessonName
                    };

                    context.Add(newIntermediate);

                    foreach(string image in i.Images)
                    {
                        IntermediateImages newImg = new IntermediateImages()
                        {
                            Path = image,
                            IntermediateId = intermediateLessonId
                        };

                        context.Add(newImg);
                    }
                    
                    intermediateLessonId ++;
                }

                var advanced = new Advanced_2[]
                {
                    new Advanced_2 { 
                        LessonName = "Altered_Chords",
                        Images = new List<string>() 
                        {
                            "/images/3-Advanced/Altered_Chords/2-5-1_Atlered5.png", 
                            "/images/3-Advanced/Altered_Chords/Altered_C7_chords.gif",
                            "/images/3-Advanced/Altered_Chords/Altered_C7chords_6.gif.gif",
                            "/images/3-Advanced/Altered_Chords/Altered_G7_chords.png.gif"
                        }
                    },
                    new Advanced_2 { 
                        LessonName = "Exercises_Practice",
                        Images = new List<string>()
                        { 
                            "/images/3-Advanced/Exercises_Practice/Am_Sweeps.png", 
                            "/images/3-Advanced/Exercises_Practice/Jazzy2_5_1.png",
                            "/images/3-Advanced/Exercises_Practice/UpTwoDownOne_C_Scale.png"
                        }
                    },
                    new Advanced_2 { 
                        LessonName = "JazzMinor_Over_7chords",
                        Images = new List<string>()
                        {
                            "/images/3-Advanced/JazzMinor_Over_7chords/2-5-1_Key_C.png", 
                            "/images/3-Advanced/JazzMinor_Over_7chords/2-5-1_KeyOfC.jpg",
                            "/images/3-Advanced/JazzMinor_Over_7chords/DomG7_1-4-5.png",
                            "/images/3-Advanced/JazzMinor_Over_7chords/Gdom7_jazzVoicing.png"
                        } 
                    },
                    new Advanced_2 { 
                        LessonName = "Superimposition",
                        Images = new List<string>() 
                        {
                            "/images/3-Advanced/Superimposition/2-5-1_with_B_Over_D7.png", 
                            "/images/3-Advanced/Superimposition/Emin_Pentatonic_Over_Am7_Chord.png",
                            "/images/3-Advanced/Superimposition/triad_superimposition_2-5-1.png",
                            "/images/3-Advanced/Superimposition/Triad_Superimposition_B_Over_D7.png"
                        }
                    },
                    new Advanced_2 { 
                        LessonName = "UpperPartials",
                        Images = new List<string>() 
                        {
                            "/images/3-Advanced/UpperPartials/2_OctaveChartForUpperPartials.png", 
                            "/images/3-Advanced/UpperPartials/Chord_Extentions_Key_C.png"
                        }
                    }
                };

                int advancedLessonId = 1;
                foreach(Advanced_2 i in advanced)
                {
                    Advanced newAdvanced = new Advanced()
                    {
                        LessonName = i.LessonName
                    };

                    context.Add(newAdvanced);
                    foreach(string image in i.Images)
                    {
                        AdvancedImages newImg = new AdvancedImages()
                        {
                            Path = image,
                            AdvancedId = advancedLessonId
                        };

                        context.Add(newImg);
                    }
                    advancedLessonId ++;
                }

                var resources = new Resources_2[]
                {
                    new Resources_2 { 
                        ResourceType = "Templates",
                        Images = new List<string>() 
                        {
                            "/images/Resources/Templates/12_fret_template.png", 
                            "/images/Resources/Templates/15_fret_diagrams.pdf", 
                            "/images/Resources/Templates/16_fret_template.png", 
                            "/images/Resources/Templates/23_fret_template.jpg", 
                            "/images/Resources/Templates/chord_diagram_templates.png", 
                            "/images/Resources/Templates/fretboard_19frets.png" 
                        }
                    }
                };
                
                int resourcesTypeId = 1;
                foreach(Resources_2 i in resources)
                {
                    Resources newResource = new Resources()
                    {
                        ResourceType = i.ResourceType
                    };

                    context.Add(newResource);
                    foreach(string image in i.Images)
                    {
                        ResourcesImages newImg = new ResourcesImages()
                        {
                            Path = image,
                            ResourcesId = resourcesTypeId
                        };

                        context.Add(newImg);
                    }
                    advancedLessonId ++;
                }
                    context.SaveChanges();
            }
       }
    }
}