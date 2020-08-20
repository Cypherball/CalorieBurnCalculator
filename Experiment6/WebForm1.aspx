<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Experiment6.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head runat="server">
    <title>Experiment 6</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" integrity="sha384-JcKb8q3iqJ61gNV9KGb8thSsNjpSL0n8PARn9HuZOnIxN0hoP+VmmDGMN5t9UJ0Z" crossorigin="anonymous">
</head>
<body>
    <div class="container mt-5">
        <h1>Calorie Burn Calculator</h1>
        <p>Find out how many calories you burn doing different activities. The calculator uses the type of physical activity and your basal metabolic rate to calculate calories burned, so gives a personalised result. Knowing roughly how many calories you expend doing different activities can help you with weight loss or maintenance.</p>
        <form id="form1" runat="server" class="mt-5">
            <div class="form-group row">
                <label class="col-sm-2 col-form-label">Gender: </label>
                <div class="form-check form-check-inline">
                    <asp:RadioButton ID="genderInputMale" CssClass="form-check-input" runat="server" GroupName="genderInput"/>
                    <label class="form-check-label" for="genderInputMale">Male</label>
                </div>
                <div class="form-check form-check-inline">
                    <asp:RadioButton ID="genderInputFemale" CssClass="form-check-input" runat="server" GroupName="genderInput"/>
                    <label class="form-check-label" for="genderInputFemale">Female</label>
                </div>
            </div>
            <div class="form-group row">
                <label for="heightInput" class="col-sm-2 col-form-label">Height (in cm): </label>
                <div class="col-sm-10">
                    <asp:TextBox ID="heightInput" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <label for="weightInput" class="col-sm-2 col-form-label">Weight (in kg): </label>
                <div class="col-sm-10">
                  <asp:TextBox ID="weightInput" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <label for="ageInput" class="col-sm-2 col-form-label">Age (years): </label>
                <div class="col-sm-10">
                  <asp:TextBox ID="ageInput" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <label for="activityInput" class="col-sm-2 col-form-label">Activity: </label>
                <div class="col-sm-10">
                    <asp:DropDownList ID="activityInput" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div class="form-group row">
                <label for="lenInput" class="col-sm-2 col-form-label">Length of Activity (in min): </label>
                <div class="col-sm-10">
                  <asp:TextBox ID="lenInput" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                </div>
            </div>
            <asp:Button ID="calculateCaloriesBurned" CssClass="btn btn-primary btn-lg btn-block" runat="server" Text="Calculate" OnClick="calculateCaloriesBurned_Click"></asp:Button>
        </form>

        <div class="container my-4">
            <asp:Label ID="errorLabel" CssClass="p-3 bg-danger text-white rounded" runat="server" Text=""></asp:Label>
        </div>
        
        <div class="container my-5 border border-success rounded">
            <h3>Result</h3><br />
            <p><strong>Activity:</strong> <asp:Label ID="activityLabel" runat="server"></asp:Label></p>
            <p><strong>Activity Time:</strong> <asp:Label ID="lenLabel" runat="server" Text="0"></asp:Label>min</p>
            <p class="p-3 bg-success text-white rounded"><strong>Energy Burned:</strong> <asp:Label ID="kcalLabel" runat="server" Text="0"></asp:Label>kcal / <asp:Label ID="kjLabel" runat="server" Text="0"></asp:Label>kJ</p>
            <p class="p-3 bg-success text-white rounded"><strong>Energy Burned Per Hour:</strong> <asp:Label ID="kcalLabelHour" runat="server" Text="0"></asp:Label>kcal / <asp:Label ID="kjLabelHour" runat="server" Text="0"></asp:Label>kJ</p>
        </div>
    </div>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js" integrity="sha384-B4gt1jrGC7Jh4AgTPSdUtOBvfO8shuf57BaghqFfPlYxofvL8/KUEfYiJOMMV+rV" crossorigin="anonymous"></script>
</body>
</html>
