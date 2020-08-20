using System;
using System.Collections;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Experiment6
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private string[] ActivityArray;
        private double[] ActivityValues;

        protected void Page_Load(object sender, EventArgs e)
        {
            ActivityArray = new string[160];    //string values of activies
            ActivityValues = new double[160];   //MET values of activities

            //populate the arrays
            set_activity_array();
            set_activity_values();

            //Add activities and their MET Values to dropdown
            for (int i = 0; i < ActivityArray.Length; i++)
            {
                activityInput.Items.Add(new ListItem(ActivityArray[i]));
            }

            errorLabel.Visible = false;
        }
        protected void calculateCaloriesBurned_Click(object sender, EventArgs e)
        {
            //Only calculate if all fields are filled.
            if(heightInput.Text!="" 
                && weightInput.Text!=""
                && ageInput.Text!="" 
                && lenInput.Text!="" 
                && activityInput.SelectedValue != "" 
                && (genderInputMale.Checked || genderInputFemale.Checked))
            {
                errorLabel.Text = "";
                errorLabel.Visible = false;
                //Caculate result and display
                calculate();
            } 
            else
            {
                //Display error and reset output
                errorLabel.Visible = true;
                errorLabel.Text = "Error: Please fill all fields!";
                activityLabel.Text = "";
                lenLabel.Text = "0";
                kcalLabel.Text = "0";
                kjLabel.Text = "0";
                kcalLabelHour.Text = "0";
                kjLabelHour.Text = "0";
            }
        }

        
        private void calculate()
        {
            //Get inputs
            int height = int.Parse(heightInput.Text);
            int weight = int.Parse(weightInput.Text);
            int age = int.Parse(ageInput.Text);
            int time = int.Parse(lenInput.Text);

            double v1, v2, vres, vreskJ;
            double mets = ActivityValues[activityInput.SelectedIndex];

            if (genderInputMale.Checked)
                v1 = 66.5 + (13.75 * weight) + (5.003 * height) - (6.775 * age);
            else
                v1 = 655.1 + (9.563 * weight) + (1.85 * height) - (4.676 * age);

            //Calories burned per hour
            v1 = (v1 * mets) / 24; //in kcal
            v2 = v1 * 4.184; //in kJ
            
            kcalLabelHour.Text = Convert.ToString(Math.Round(v1));
            kjLabelHour.Text = Convert.ToString(Math.Round(v2));

            //Calories burned in given time
            vres = Math.Round(v1 * time / 60); //in kcal
            vreskJ = Math.Round(v2 * time / 60); //in kJ

            kcalLabel.Text = Convert.ToString(vres);
            kjLabel.Text = Convert.ToString(vreskJ);

            activityLabel.Text = ActivityArray[activityInput.SelectedIndex];
            lenLabel.Text = lenInput.Text;
        }

        private void set_activity_array()
        {
            ActivityArray[0] = "";
            ActivityArray[1] = "Aqua aerobics";
            ActivityArray[2] = "Athletics, high jump, long jump, triple jump, javelin, pole vault";
            ActivityArray[3] = "Athletics, shot, discus, hammer";
            ActivityArray[4] = "Athletics, steeplechase, hurdles";
            ActivityArray[5] = "Badminton, competitive";
            ActivityArray[6] = "Badminton, social";
            ActivityArray[7] = "Baseball";
            ActivityArray[8] = "Basketball, game";
            ActivityArray[9] = "Basketball, shooting baskets";
            ActivityArray[10] = "Bowling";
            ActivityArray[11] = "Boxing, punching bag";
            ActivityArray[12] = "Boxing, sparring";
            ActivityArray[13] = "Calisthenics, heavy, vigorous effort";
            ActivityArray[14] = "Calisthenics, light or moderate effort";
            ActivityArray[15] = "Canoeing, rowing, light effort";
            ActivityArray[16] = "Canoeing, rowing, moderate effort";
            ActivityArray[17] = "Canoeing, rowing, vigorous effort";
            ActivityArray[18] = "Carpentry, general";
            ActivityArray[19] = "Carpentry, rain gutters, fencing";
            ActivityArray[20] = "Carpentry, sawing hardwood";
            ActivityArray[21] = "Carpet laying/removal";
            ActivityArray[22] = "Carrying groceries upstairs";
            ActivityArray[23] = "Chopping wood";
            ActivityArray[24] = "Circuit training, general";
            ActivityArray[25] = "Cleaning gutters";
            ActivityArray[26] = "Cleaning, house, general";
            ActivityArray[27] = "Conditioning exercise, health club exercise, general";
            ActivityArray[28] = "Conditioning exercise, stretching, hatha yoga";
            ActivityArray[29] = "Cricket [batting, bowling]";
            ActivityArray[30] = "Cycling, less than 16.1 km/height";
            ActivityArray[31] = "Cycling, 16.1-19.2 km/height";
            ActivityArray[32] = "Cycling, 19.3-22.4 km/height";
            ActivityArray[33] = "Cycling, 22.5-25.6 km/height";
            ActivityArray[34] = "Cycling, 25.7-30.6 km/height, racing not drafting";
            ActivityArray[35] = "Cycling, drafting at more than 30.6 km/height, very fast, racing general";
            ActivityArray[36] = "Cycling, more than 32.2 km/height, racing not drafting";
            ActivityArray[37] = "Cycling, BMX or mountain";
            ActivityArray[38] = "Cycling, general";
            ActivityArray[39] = "Cycling, stationary, 50 watts, very light effort";
            ActivityArray[40] = "Cycling, stationary, 100 watts, light effort";
            ActivityArray[41] = "Cycling, stationary, 150 watts, moderate effort";
            ActivityArray[42] = "Cycling, stationary, 200 watts, vigorous effort";
            ActivityArray[43] = "Cycling, stationary, 250 watts, very vigorous effort";
            ActivityArray[44] = "Dancing, aerobic general";
            ActivityArray[45] = "Dancing, ballet, modern, jazz, tap, jitterbug";
            ActivityArray[46] = "Dancing, ballroom, slow";
            ActivityArray[47] = "Dancing, Greek, Middle Eastern, hula, flamenco, belly, swing";
            ActivityArray[48] = "Diving, springboard or platform";
            ActivityArray[49] = "Elliptical trainer";
            ActivityArray[50] = "Fencing";
            ActivityArray[51] = "Fishing, general";
            ActivityArray[52] = "Football, competitive";
            ActivityArray[53] = "Frisbee, general";
            ActivityArray[54] = "Frisbee, ultimate";
            ActivityArray[55] = "Gardening, digging";
            ActivityArray[56] = "Gardening, general";
            ActivityArray[57] = "Gardening, mowing lawn";
            ActivityArray[58] = "Gardening, planting trees";
            ActivityArray[59] = "Gardening, raking lawn";
            ActivityArray[60] = "Golf, general";
            ActivityArray[61] = "Gymnastics";
            ActivityArray[62] = "Handball, team";
            ActivityArray[63] = "Hockey, field or ice";
            ActivityArray[64] = "Horseback riding, general";
            ActivityArray[65] = "Household cleaning, general";
            ActivityArray[66] = "Household tasks, moderate effort";
            ActivityArray[67] = "Hunting, general";
            ActivityArray[68] = "Ice skating";
            ActivityArray[69] = "Ironing";
            ActivityArray[70] = "Judo, jujitsu, karate, kickboxing, tae kwan do";
            ActivityArray[71] = "Kayaking";
            ActivityArray[72] = "Lacrosse";
            ActivityArray[73] = "Lawn bowls";
            ActivityArray[74] = "Motorcross";
            ActivityArray[75] = "Moving furniture, household items, carrying boxes";
            ActivityArray[76] = "Orienteering";
            ActivityArray[77] = "Painting, papering, plastering";
            ActivityArray[78] = "Pilates";
            ActivityArray[79] = "Polo";
            ActivityArray[80] = "Rock climbing, ascending";
            ActivityArray[81] = "Rock climbing, rappelling";
            ActivityArray[82] = "Rollerblading";
            ActivityArray[83] = "Rollerskating";
            ActivityArray[84] = "Roofing";
            ActivityArray[85] = "Rowing machine, general";
            ActivityArray[86] = "Rugby";
            ActivityArray[87] = "Running, 3 mins 26 secs per km";
            ActivityArray[88] = "Running, 3 mins 44 secs per km";
            ActivityArray[89] = "Running, 4 mins 9 secs per km";
            ActivityArray[90] = "Running, 4 mins 20 secs per km";
            ActivityArray[91] = "Running, 4 mins 40 secs per km";
            ActivityArray[92] = "Running, 5 mins per km";
            ActivityArray[93] = "Running, 5.5 mins per km";
            ActivityArray[94] = "Running, 6 mins 12 secs per km";
            ActivityArray[95] = "Running, 7 mins 10 secs per km";
            ActivityArray[96] = "Running, 7.5 mins per km";
            ActivityArray[97] = "Running, cross country";
            ActivityArray[98] = "Running, jog/walk combination";
            ActivityArray[99] = "Running, up stairs";
            ActivityArray[100] = "Sailing, competition";
            ActivityArray[101] = "Sailing, general";
            ActivityArray[102] = "Scuba diving";
            ActivityArray[103] = "Sexual activity, light effort";
            ActivityArray[104] = "Sexual activity, moderate effort";
            ActivityArray[105] = "Sexual activity, vigorous effort";
            ActivityArray[106] = "Skateboarding";
            ActivityArray[107] = "Skiing";
            ActivityArray[108] = "Skipping, with rope";
            ActivityArray[109] = "Sledding, tobogganing";
            ActivityArray[110] = "Snorkelling";
            ActivityArray[111] = "Snow shoeing";
            ActivityArray[112] = "Soccer, casual";
            ActivityArray[113] = "Soccer, competitive";
            ActivityArray[114] = "Softball";
            ActivityArray[115] = "Softball, pitching";
            ActivityArray[116] = "Speed skating competitive";
            ActivityArray[117] = "Squash";
            ActivityArray[118] = "Stair-treadmill ergometer, general";
            ActivityArray[119] = "Step aerobics, high step";
            ActivityArray[120] = "Step aerobics, low step";
            ActivityArray[121] = "Stretching";
            ActivityArray[122] = "Surfing, body or board";
            ActivityArray[123] = "Sweeping floors, carpets";
            ActivityArray[124] = "Swimming laps, freestyle, moderate or light effort";
            ActivityArray[125] = "Swimming laps, freestyle, vigorous";
            ActivityArray[126] = "Swimming, backstroke";
            ActivityArray[127] = "Swimming, breaststroke";
            ActivityArray[128] = "Swimming, butterfly";
            ActivityArray[129] = "Table tennis [ping pong]";
            ActivityArray[130] = "Tai chi";
            ActivityArray[131] = "Tennis, doubles";
            ActivityArray[132] = "Tennis, general";
            ActivityArray[133] = "Tennis, singles";
            ActivityArray[134] = "Touch football";
            ActivityArray[135] = "Trampoline";
            ActivityArray[136] = "Vacuuming";
            ActivityArray[137] = "Volleyball, 6-9 member team";
            ActivityArray[138] = "Volleyball, beach";
            ActivityArray[139] = "Volleyball, indoor competitive";
            ActivityArray[140] = "Walk/run, playing with animals - moderate";
            ActivityArray[141] = "Walk/run, playing with children - moderate";
            ActivityArray[142] = "Walking the dog";
            ActivityArray[143] = "Walking, 3.2 kph";
            ActivityArray[144] = "Walking, 4.02 kph";
            ActivityArray[145] = "Walking, 4.82 kph";
            ActivityArray[146] = "Walking, 5.6 kph";
            ActivityArray[147] = "Walking, 6.4 kph";
            ActivityArray[148] = "Walking, 7.24 kph";
            ActivityArray[149] = "Walking, 8 kph";
            ActivityArray[150] = "Watching TV, sitting quietly";
            ActivityArray[151] = "Water aerobics";
            ActivityArray[152] = "Water jogging";
            ActivityArray[153] = "Water polo";
            ActivityArray[154] = "Waterskiiing";
            ActivityArray[155] = "Weight lifting, light or moderate effort";
            ActivityArray[156] = "Weight lifting, vigorous effort";
            ActivityArray[157] = "Wiring, plumbing";
            ActivityArray[158] = "Wrestling match";
            ActivityArray[159] = "Yoga, hatha";
        }

        private void set_activity_values()
        {
            ActivityValues[0] = -1;
            ActivityValues[1] = 4;
            ActivityValues[2] = 6;
            ActivityValues[3] = 4;
            ActivityValues[4] = 10;
            ActivityValues[5] = 7;
            ActivityValues[6] = 4.5;
            ActivityValues[7] = 5;
            ActivityValues[8] = 8;
            ActivityValues[9] = 4.5;
            ActivityValues[10] = 3;
            ActivityValues[11] = 6;
            ActivityValues[12] = 9;
            ActivityValues[13] = 8;
            ActivityValues[14] = 3.5;
            ActivityValues[15] = 3;
            ActivityValues[16] = 7;
            ActivityValues[17] = 12;
            ActivityValues[18] = 3;
            ActivityValues[19] = 6;
            ActivityValues[20] = 7.5;
            ActivityValues[21] = 4.5;
            ActivityValues[22] = 7.5;
            ActivityValues[23] = 6;
            ActivityValues[24] = 8;
            ActivityValues[25] = 5;
            ActivityValues[26] = 3;
            ActivityValues[27] = 5.5;
            ActivityValues[28] = 2.5;
            ActivityValues[29] = 5;
            ActivityValues[30] = 4;
            ActivityValues[31] = 6;
            ActivityValues[32] = 8;
            ActivityValues[33] = 10;
            ActivityValues[34] = 12;
            ActivityValues[35] = 12;
            ActivityValues[36] = 16;
            ActivityValues[37] = 8.5;
            ActivityValues[38] = 8;
            ActivityValues[39] = 3;
            ActivityValues[40] = 5.5;
            ActivityValues[41] = 7;
            ActivityValues[42] = 10.5;
            ActivityValues[43] = 12.5;
            ActivityValues[44] = 6.5;
            ActivityValues[45] = 4.79999999999999;
            ActivityValues[46] = 3;
            ActivityValues[47] = 4.5;
            ActivityValues[48] = 3;
            ActivityValues[49] = 7;
            ActivityValues[50] = 6;
            ActivityValues[51] = 3;
            ActivityValues[52] = 9;
            ActivityValues[53] = 3;
            ActivityValues[54] = 8;
            ActivityValues[55] = 5;
            ActivityValues[56] = 4;
            ActivityValues[57] = 5.5;
            ActivityValues[58] = 4.5;
            ActivityValues[59] = 4.29999999999999;
            ActivityValues[60] = 4.5;
            ActivityValues[61] = 4;
            ActivityValues[62] = 8;
            ActivityValues[63] = 8;
            ActivityValues[64] = 4;
            ActivityValues[65] = 3;
            ActivityValues[66] = 3.5;
            ActivityValues[67] = 5;
            ActivityValues[68] = 7;
            ActivityValues[69] = 2.29999999999999;
            ActivityValues[70] = 10;
            ActivityValues[71] = 5;
            ActivityValues[72] = 8;
            ActivityValues[73] = 3;
            ActivityValues[74] = 4;
            ActivityValues[75] = 6;
            ActivityValues[76] = 9;
            ActivityValues[77] = 3;
            ActivityValues[78] = 3.5;
            ActivityValues[79] = 8;
            ActivityValues[80] = 11;
            ActivityValues[81] = 8;
            ActivityValues[82] = 12.5;
            ActivityValues[83] = 7;
            ActivityValues[84] = 6;
            ActivityValues[85] = 7;
            ActivityValues[86] = 10;
            ActivityValues[87] = 18;
            ActivityValues[88] = 16;
            ActivityValues[89] = 15;
            ActivityValues[90] = 14;
            ActivityValues[91] = 13.5;
            ActivityValues[92] = 12.5;
            ActivityValues[93] = 11;
            ActivityValues[94] = 10;
            ActivityValues[95] = 9;
            ActivityValues[96] = 8;
            ActivityValues[97] = 9;
            ActivityValues[98] = 6;
            ActivityValues[99] = 15;
            ActivityValues[100] = 5;
            ActivityValues[101] = 3;
            ActivityValues[102] = 7;
            ActivityValues[103] = 1;
            ActivityValues[104] = 1.3;
            ActivityValues[105] = 1.5;
            ActivityValues[106] = 5;
            ActivityValues[107] = 7;
            ActivityValues[108] = 10;
            ActivityValues[109] = 7;
            ActivityValues[110] = 5;
            ActivityValues[111] = 8;
            ActivityValues[112] = 7;
            ActivityValues[113] = 10;
            ActivityValues[114] = 5;
            ActivityValues[115] = 6;
            ActivityValues[116] = 15;
            ActivityValues[117] = 12;
            ActivityValues[118] = 9;
            ActivityValues[119] = 10;
            ActivityValues[120] = 8.5;
            ActivityValues[121] = 2.5;
            ActivityValues[122] = 3;
            ActivityValues[123] = 3.29999999999999;
            ActivityValues[124] = 7;
            ActivityValues[125] = 10;
            ActivityValues[126] = 7;
            ActivityValues[127] = 10;
            ActivityValues[128] = 11;
            ActivityValues[129] = 4;
            ActivityValues[130] = 4;
            ActivityValues[131] = 6;
            ActivityValues[132] = 7;
            ActivityValues[133] = 8;
            ActivityValues[134] = 8;
            ActivityValues[135] = 3.5;
            ActivityValues[136] = 3.5;
            ActivityValues[137] = 3;
            ActivityValues[138] = 8;
            ActivityValues[139] = 8;
            ActivityValues[140] = 4;
            ActivityValues[141] = 4;
            ActivityValues[142] = 3;
            ActivityValues[143] = 2.5;
            ActivityValues[144] = 3;
            ActivityValues[145] = 3.29999999999999;
            ActivityValues[146] = 3.79999999999999;
            ActivityValues[147] = 5;
            ActivityValues[148] = 6.29999999999999;
            ActivityValues[149] = 8;
            ActivityValues[150] = 1;
            ActivityValues[151] = 4;
            ActivityValues[152] = 8;
            ActivityValues[153] = 10;
            ActivityValues[154] = 6;
            ActivityValues[155] = 3;
            ActivityValues[156] = 6;
            ActivityValues[157] = 3;
            ActivityValues[158] = 6;
            ActivityValues[159] = 2.5;
        }
    }
}