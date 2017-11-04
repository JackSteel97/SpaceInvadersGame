'***********************************
'*SPACE INVADERS CODE BY JACK STEEL*
'***********************************

Public Class ParentForm
    Dim paused As Boolean
    Dim settingsArr(10) As String
    Dim colour As System.Drawing.Color
    Dim sfxon As Boolean
    Dim ThemeSong As New Media.SoundPlayer(My.Resources.carlosadiaz644presents_SPACE_INVADERS_OFFICIAL_THE)
    Dim ShootSfx As New Media.SoundPlayer(My.Resources.shoot)
    Dim InvaderKilledSfx As New Media.SoundPlayer(My.Resources.invaderkilled)
    Dim playerdeathsfx As New Media.SoundPlayer(My.Resources.explosion)
    Dim UFOSfx As New Media.SoundPlayer(My.Resources.ufo_lowpitch)
    Dim AShotChance As Integer = 5000
    Dim lef As Boolean
    Dim AlienShots(49) As Boolean
    Dim AlienShotLbls(49) As Label
    Dim righ As Boolean
    Dim MoveAliensdistance As Integer = 12
    Dim fire As Boolean
    Dim fire1 As Boolean
    Dim fire2 As Boolean
    Dim fire3 As Boolean
    Dim fire4 As Boolean
    Dim fire5 As Boolean
    Dim shipmovemagleft As Integer = -3
    Dim shipmovemagright As Integer = 3
    Dim Alienhit As Integer
    Dim aliens(49) As PictureBox
    Dim alienstartlocation(49) As System.Drawing.Point
    Dim kills As Integer
    Dim level As Integer = 1
    Dim score As Integer
    Dim namesave As String
    Dim viscount As Integer = 0
    Dim speedpowerupdrop As Boolean
    Dim speedactivate As Boolean
    Dim speedpowertime As Integer = 10000
    Dim shotspeed As Integer = 10
    Dim firststate As Boolean
    Dim multishotactive As Boolean = False
    Dim multishotdrop As Boolean
    Dim multishottime As Integer = 10000
    Dim ran As Integer
    Dim shieldactive As Boolean = False
    Dim shieldtime As Integer = 7500
    Dim shielddrop As Boolean
    Dim ufoMoving As Boolean
    Dim ufoshooting As Boolean
    Dim lives As Integer = 3
    Dim deathtimecount As Integer = 0
    Dim shipstartpos As System.Drawing.Point
    Dim shipshotstartpos As System.Drawing.Point
    Dim deathstart As Boolean = False




    Private Sub QuitButton_Click(sender As Object, e As EventArgs) Handles QuitButton.Click
        Me.Close()
    End Sub

    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        lives = 3
        shieldactive = False
        speedactivate = False
        multishotactive = False
        Title.Hide()
        instructions1.Hide()
        instructions2.Hide()
        instructions3.Hide()
        instructions4.Hide()
        instructions5.Hide()
        instructions6.Hide()
        SettingsButton.Hide()
        UFO.Left = Me.Width + 500
        UFOShot.Left = UFO.Left + 37
        UFOShot.Top = UFO.Top + 40
        StartAlien.Hide()
        StartShip.Hide()
        StartButton.Hide()
        QuitButton.Hide()
        Panel1.Show()
        Highscoresdisp.Hide()
        Mover.Enabled = True
        Mover.Start()
        AlienMover.Enabled = True
        AlienMover.Start()
        Controlsbox.Hide()
        InitializeAShotPosition()
        lef = False
        righ = False
        Ship.BringToFront()
        DeadDisplay.BringToFront()
        Shield.Parent = Ship
        Shield.BackColor = Color.Transparent
        Shield.BringToFront()
        leveldone.BringToFront()
        fire = False
        fire1 = False
        fire2 = False
        fire3 = False
        fire4 = False
        fire5 = False
        kills = 0
        Shot1.Location = ResetShot.Location
        Shot2.Location = ResetShot.Location
        Shot3.Location = ResetShot.Location
        Shot4.Location = ResetShot.Location
        Shot5.Location = ResetShot.Location
        score = 0
        SpeedPowerup.Hide()
        MissilePowerUp.Hide()
        ShieldPowerup.Hide()
        Shield.BringToFront()
        shipshotstartpos = ResetShot.Location
        Panel1.Width = Me.Width
        Panel1.Height = Me.Height
        Ship.Top = 663
        ResetShot.Top = 650
        Shot1.Top = ResetShot.Top
        Shot2.Top = ResetShot.Top
        Shot3.Top = ResetShot.Top
        Shot4.Top = ResetShot.Top
        Shot5.Top = ResetShot.Top
        Life1.Top = 685
        Life2.Top = Life1.Top
        Life3.Top = Life1.Top
        InvasionDetector.Top = 673
        If Me.Height >= 800 Then
            Ship.Top = Ship.Top + 65
            ResetShot.Top = ResetShot.Top + 65
            Shot1.Top = ResetShot.Top
            Shot2.Top = ResetShot.Top
            Shot3.Top = ResetShot.Top
            Shot4.Top = ResetShot.Top
            Shot5.Top = ResetShot.Top
            Life1.Top = Life1.Top + 93
            Life2.Top = Life1.Top
            Life3.Top = Life1.Top
            InvasionDetector.Top = InvasionDetector.Top + 55
        End If
        Life1.Show()
        Life2.Show()
        Life3.Show()
        shipstartpos = Ship.Location
        Ship.Location = shipstartpos

    End Sub

    Private Sub Mover_Tick(sender As Object, e As EventArgs) Handles Mover.Tick
        droppowerup()
        MoveUFO()
        PowerUpTimersactivator()
        Scorelbl.Text = "Score: " & score

        If leveldone.Visible = True Then
            If viscount >= 50 Then
                leveldone.Visible = False
                viscount = 0
            Else
                viscount = viscount + 1
            End If
        End If
        If speedpowerupdrop = True Then
            SpeedPowerup.Top = SpeedPowerup.Top + 2
            If SpeedPowerup.Bounds.IntersectsWith(Ship.Bounds) Then
                SpeedPowerup.Visible = False
                speedpowerupdrop = False
                If speedactivate = False Then
                    speedactivate = True
                Else
                    speedpowertime = speedpowertime + 5000
                End If
            ElseIf SpeedPowerup.Top > 1000 Then
                speedpowerupdrop = False
            End If
        End If
        If speedactivate = True Then
            If speedpowertime <= 0 Then
                speedactivate = False
                speedpowertime = 10000
                shipmovemagleft = -3
                shipmovemagright = 3
            Else
                shipmovemagleft = -10
                shipmovemagright = 10
                speedpowertime = speedpowertime - 10
            End If

        End If
        If multishotdrop = True Then
            MissilePowerUp.Top = MissilePowerUp.Top + 2
            If MissilePowerUp.Bounds.IntersectsWith(Ship.Bounds) Then
                MissilePowerUp.Visible = False
                multishotdrop = False
                If multishotactive = False Then
                    multishotactive = True
                Else
                    multishottime = multishottime + 5000
                End If
            ElseIf MissilePowerUp.Top > 1000 Then
                multishotdrop = False
            End If
        End If
        If multishotactive = True Then
            If multishottime <= 0 Then
                multishotactive = False
                multishottime = 10000
            Else
                multishotactive = True
                multishottime = multishottime - 10
            End If

        End If

        If shielddrop = True Then
            ShieldPowerup.Top = ShieldPowerup.Top + 2
            If ShieldPowerup.Bounds.IntersectsWith(Ship.Bounds) Then
                ShieldPowerup.Visible = False
                shielddrop = False
                If shieldactive = False Then
                    shieldactive = True
                    Shield.Show()
                Else
                    shieldtime = shieldtime + 5000
                End If
            ElseIf ShieldPowerup.Top > 1000 Then
                shielddrop = False
            End If
        End If
        If shieldactive = True Then
            If shieldtime <= 0 Then
                shieldactive = False
                Shield.Hide()
                shieldtime = 7500
            Else
                shieldactive = True
                shieldtime = shieldtime - 10
            End If

        End If
        If lef = True Then
            If Ship.Left > 0 Then


                Ship.Left = Ship.Left + shipmovemagleft
                ResetShot.Left = ResetShot.Left + shipmovemagleft
                If fire1 = False Then
                    Shot1.Left = Shot1.Left + shipmovemagleft
                End If
                If fire2 = False Then
                    Shot2.Left = Shot2.Left + shipmovemagleft
                End If
                If fire3 = False Then
                    Shot3.Left = Shot3.Left + shipmovemagleft
                End If
                If fire4 = False Then
                    Shot4.Left = Shot4.Left + shipmovemagleft
                End If
                If fire5 = False Then
                    Shot5.Left = Shot5.Left + shipmovemagleft
                End If
            End If
        End If

        If righ = True Then
            If Ship.Left < Me.Width - Ship.Width Then
                Ship.Left = Ship.Left + shipmovemagright
                ResetShot.Left = ResetShot.Left + shipmovemagright
                If fire1 = False Then
                    Shot1.Left = Shot1.Left + shipmovemagright
                End If
                If fire2 = False Then
                    Shot2.Left = Shot2.Left + shipmovemagright
                End If
                If fire3 = False Then
                    Shot3.Left = Shot3.Left + shipmovemagright
                End If
                If fire4 = False Then
                    Shot4.Left = Shot4.Left + shipmovemagright
                End If
                If fire5 = False Then
                    Shot5.Left = Shot5.Left + shipmovemagright
                End If
            End If
        End If
        If fire = True Then
            checkshot()
        End If
        moveshot()
        MoveAlienShots()
        MoveUFO()
        UFOFire()
    End Sub

    Private Sub shipmover(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Left Then
            lef = True
        End If
        If e.KeyValue = Keys.Right Then
            righ = True
        End If
        If e.KeyCode = Keys.F Then
            fire = True
        End If
        If e.KeyCode = Keys.Space Then
            e.Handled = True
        End If
        If e.KeyCode = Keys.P Then
            If paused = False Then
                paused = True
                Mover.Enabled = False
                AlienMover.Enabled = False
                ShieldTimer.Enabled = False
                PauseTimer.Enabled = True

                Pauselbl.Visible = True
            Else
                paused = False
                Mover.Enabled = True
                AlienMover.Enabled = True
                ShieldTimer.Enabled = True
                PauseTimer.Enabled = False
                Pauselbl.Visible = False

            End If
        End If
        If e.KeyCode = Keys.Q Then
            If paused = True Then
                paused = False
                PauseTimer.Enabled = False
                Pauselbl.Hide()
                shieldactive = False
                speedactivate = False
                multishotactive = False
                Title.Show()
                SettingsButton.Show()
                StartAlien.Show()
                StartShip.Show()
                StartButton.Show()
                QuitButton.Show()
                Panel1.Hide()
                Mover.Enabled = False
                AlienMover.Enabled = False
                Controlsbox.Show()
                lef = False
                righ = False
                fire = False
                fire1 = False
                fire2 = False
                fire3 = False
                fire4 = False
                fire5 = False
                kills = 0
                Shot1.Location = ResetShot.Location
                Shot2.Location = ResetShot.Location
                Shot3.Location = ResetShot.Location
                Shot4.Location = ResetShot.Location
                Shot5.Location = ResetShot.Location
                SpeedPowerup.Hide()
                MissilePowerUp.Hide()
                ShieldPowerup.Hide()
                shipshotstartpos = ResetShot.Location
                Panel1.Width = Me.Width
                Panel1.Height = Me.Height
                Highscoresdisp.Show()
                If Me.Height >= 800 Then
                    Ship.Top = Ship.Top + 65
                    ResetShot.Top = ResetShot.Top + 65
                    Shot1.Top = ResetShot.Top
                    Shot2.Top = ResetShot.Top
                    Shot3.Top = ResetShot.Top
                    Shot4.Top = ResetShot.Top
                    Shot5.Top = ResetShot.Top
                    Life1.Top = Life1.Top + 93
                    Life2.Top = Life1.Top
                    Life3.Top = Life1.Top
                    InvasionDetector.Top = InvasionDetector.Top + 55
                End If
                AlienMover.Interval = 1000
                playerDied()
            End If
        End If
    End Sub

    Private Sub ShipStop(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyValue = Keys.Left Then
            lef = False
        End If
        If e.KeyValue = Keys.Right Then
            righ = False
        End If
        If e.KeyValue = Keys.F Then
            fire = False
        End If
    End Sub

    Public Sub New()

        InitializeComponent()
        CreateArray()
        LoadAlienShots()
        InitializeAShotPosition()
        firststate = True
        Me.WindowState = FormWindowState.Maximized
        Dim count As Integer = 0

        Try

            FileOpen(1, "Settings.txt", OpenMode.Input)
            While EOF(1) = False
                settingsArr(count) = LineInput(1)
                count = count + 1
            End While
            FileClose(1)
            Gamepacelbl.Parent = Settingspanel
            SettingsGamePace.Parent = Settingspanel
            SettingsSave.Parent = Settingspanel
            SettingsGameMechanics.Parent = Settingspanel
            If settingsArr(0) = "False" Then
                sfxon = True
                SettingsMusic.Checked = False
                SettingsSFX.Checked = True
            ElseIf settingsArr(1) = "False" Then
                sfxon = False
                SettingsMusic.Checked = True
                SettingsSFX.Checked = False
            End If
            SettingsDifficultylvl.Value = settingsArr(2)
            If SettingsDifficultylvl.Value = 0 Then
                AShotChance = 0
            ElseIf SettingsDifficultylvl.Value = 1 Then
                AShotChance = 9000
            ElseIf SettingsDifficultylvl.Value = 2 Then
                AShotChance = 8000
            ElseIf SettingsDifficultylvl.Value = 3 Then
                AShotChance = 7000
            ElseIf SettingsDifficultylvl.Value = 4 Then
                AShotChance = 6000
            ElseIf SettingsDifficultylvl.Value = 5 Then
                AShotChance = 4000
            ElseIf SettingsDifficultylvl.Value = 6 Then
                AShotChance = 3500
            ElseIf SettingsDifficultylvl.Value = 7 Then
                AShotChance = 3000
            ElseIf SettingsDifficultylvl.Value = 8 Then
                AShotChance = 2500
            ElseIf SettingsDifficultylvl.Value = 9 Then
                AShotChance = 2000
            ElseIf SettingsDifficultylvl.Value = 10 Then
                AShotChance = 1000
            End If

            Difficultylbl.Text = "Difficulty: " & SettingsDifficultylvl.Value

            SettingsGamePace.Value = settingsArr(3)
            Gamepacelbl.Text = "Game Pace:" & SettingsGamePace.Value & "x Speed"
            AlienMover.Interval = 1000 / SettingsGamePace.Value
        Catch ex As Exception
            MsgBox("No Settings data file found" & Chr(13) & "Using Defaults...")
        End Try
        MechanicsPanel2.Parent = Me
    End Sub

    Private Sub CreateArray()

        aliens(0) = Alien1
        aliens(1) = Alien2
        aliens(2) = Alien3
        aliens(3) = Alien4
        aliens(4) = Alien5
        aliens(5) = Alien6
        aliens(6) = Alien7
        aliens(7) = Alien8
        aliens(8) = Alien9
        aliens(9) = Alien10
        aliens(10) = Alien11
        aliens(11) = Alien12
        aliens(12) = Alien13
        aliens(13) = Alien14
        aliens(14) = Alien15
        aliens(15) = Alien16
        aliens(16) = Alien17
        aliens(17) = Alien18
        aliens(18) = Alien19
        aliens(19) = Alien20
        aliens(20) = Alien21
        aliens(21) = Alien22
        aliens(22) = Alien23
        aliens(23) = Alien24
        aliens(24) = Alien25
        aliens(25) = Alien26
        aliens(26) = Alien27
        aliens(27) = Alien28
        aliens(28) = Alien29
        aliens(29) = Alien30
        aliens(30) = Alien31
        aliens(31) = Alien32
        aliens(32) = Alien33
        aliens(33) = Alien34
        aliens(34) = Alien35
        aliens(35) = Alien36
        aliens(36) = Alien37
        aliens(37) = Alien38
        aliens(38) = Alien39
        aliens(39) = Alien40
        aliens(40) = Alien41
        aliens(41) = Alien42
        aliens(42) = Alien43
        aliens(43) = Alien44
        aliens(44) = Alien45
        aliens(45) = Alien46
        aliens(46) = Alien47
        aliens(47) = Alien48
        aliens(48) = Alien49
        aliens(49) = Alien50
        For i = 0 To 49
            alienstartlocation(i) = aliens(i).Location
        Next
    End Sub

    Private Sub movealiens()
        For i = 0 To 49
            aliens(i).Left = aliens(i).Left + MoveAliensdistance
            If AlienShots(i) = False Then
                AlienShotLbls(i).Left = AlienShotLbls(i).Left + MoveAliensdistance
            End If

            If firststate = True Then
                aliens(i).Image = My.Resources.invaderpos2
            Else
                aliens(i).Image = My.Resources.space_invadertrans
            End If
            If aliens(i).Bounds.IntersectsWith(Ship.Bounds) Or aliens(i).Bounds.IntersectsWith(InvasionDetector.Bounds) Then
                playerDied()

            End If
        Next
        If firststate = True Then
            firststate = False
        Else
            firststate = True
        End If
        If Alien12.Left > Me.Width - Alien12.Width Then
            MoveAliensdistance = MoveAliensdistance * -1
            For i = 0 To 49
                aliens(i).Top = aliens(i).Top + 50
                If AlienShots(i) = False Then
                    AlienShotLbls(i).Top = AlienShotLbls(i).Top + 50
                End If
            Next
        End If
        If Alien1.Left < 0 Then
            MoveAliensdistance = MoveAliensdistance * -1
            For i = 0 To 49
                aliens(i).Top = aliens(i).Top + 50
                If AlienShots(i) = False Then
                    AlienShotLbls(i).Top = AlienShotLbls(i).Top + 50
                End If

            Next

        End If
    End Sub
    Private Sub playerDied()
        Mover.Stop()
        AlienMover.Stop()

        Ship.Image = My.Resources.Fire_Explosion_PNG_Picture_Clipart
        DeadDisplay.Text = "GAME OVER"
        DeadDisplay.Show()
        namesave = InputBox("Your Final score is: " & score & Chr(13) & "Enter your name")
        If Not score < 0 And Not namesave = "" Then
            FileOpen(1, "Highscores.txt", OpenMode.Append)
            PrintLine(1, namesave & ": " & score & Chr(13))
            FileClose(1)
        End If
        Title.Show()
        SettingsButton.Show()
        instructions1.Show()
        instructions2.Show()
        instructions3.Show()
        instructions4.Show()
        instructions5.Show()
        instructions6.Show()
        Controlsbox.Show()

        StartAlien.Show()
        StartShip.Show()
        StartButton.Show()
        QuitButton.Show()
        Highscoresdisp.Show()
        Highscoreslist.Hide()
        Highscoreslist.Text = ""
        Back.Hide()
        Panel1.Hide()
        kills = 0
        level = 1
        For i = 0 To 49
            aliens(i).Location = alienstartlocation(i)
        Next
        MoveAliensdistance = 12
        score = 0
        Ship.Image = My.Resources.ship
        DeadDisplay.Hide()
    End Sub

    Private Sub checkshot()
        If deathstart = False Then
            fire = False

            If fire1 = False Then
                fire1 = True
                Shot1.Show()
                If sfxon = True Then
                    ShootSfx.Play()
                End If

                Exit Sub
            End If

            If multishotactive = True Then
                If fire2 = False Then
                    fire2 = True
                    Shot2.Show()
                    If sfxon = True Then
                        ShootSfx.Play()
                    End If
                    Exit Sub
                End If
                If fire3 = False Then
                    fire3 = True
                    Shot3.Show()
                    If sfxon = True Then
                        ShootSfx.Play()
                    End If
                    Exit Sub
                End If
                If fire4 = False Then
                    fire4 = True
                    Shot4.Show()
                    If sfxon = True Then
                        ShootSfx.Play()
                    End If
                    Exit Sub
                End If
                If fire5 = False Then
                    fire5 = True
                    Shot5.Show()
                    If sfxon = True Then
                        ShootSfx.Play()
                    End If
                    Exit Sub
                End If
            Else
                Shot2.Hide()
                Shot3.Hide()
                Shot4.Hide()
                Shot5.Hide()
                Shot2.Location = ResetShot.Location
                Shot3.Location = ResetShot.Location
                Shot4.Location = ResetShot.Location
                Shot5.Location = ResetShot.Location
            End If

        End If
    End Sub

    Private Sub moveshot()
        If fire1 = True Then
            Shot1.Top = Shot1.Top - shotspeed
            For i = 0 To 49
                If Shot1.Bounds.IntersectsWith(aliens(i).Bounds) Then
                    Alienhit = i
                    Shot1hit()
                ElseIf Shot1.Bounds.IntersectsWith(UFO.Bounds) Then
                    shot1hitUFO()

                End If
            Next
            If Shot1.Top < 0 Then
                Shot1.Hide()
                fire1 = False
                Shot1.Location = ResetShot.Location
            End If
        End If

        If multishotactive = True Then


            If fire2 = True Then
                Shot2.Top = Shot2.Top - shotspeed
                For i = 0 To 49
                    If Shot2.Bounds.IntersectsWith(aliens(i).Bounds) Then
                        Alienhit = i
                        Shot2hit()
                    ElseIf Shot2.Bounds.IntersectsWith(UFO.Bounds) Then
                        shot2hitUFO()
                    End If
                Next
                If Shot2.Top < 0 Then
                    Shot2.Hide()
                    fire2 = False
                    Shot2.Location = ResetShot.Location
                End If
            End If
            If fire3 = True Then
                Shot3.Top = Shot3.Top - shotspeed
                For i = 0 To 49
                    If Shot3.Bounds.IntersectsWith(aliens(i).Bounds) Then
                        Alienhit = i
                        Shot3hit()
                    ElseIf Shot3.Bounds.IntersectsWith(UFO.Bounds) Then
                        shot3hitUFO()
                    End If
                Next
                If Shot3.Top < 0 Then
                    Shot3.Hide()
                    fire3 = False
                    Shot3.Location = ResetShot.Location
                End If
            End If
            If fire4 = True Then
                Shot4.Top = Shot4.Top - shotspeed
                For i = 0 To 49
                    If Shot4.Bounds.IntersectsWith(aliens(i).Bounds) Then
                        Alienhit = i
                        Shot4hit()
                    ElseIf Shot4.Bounds.IntersectsWith(UFO.Bounds) Then
                        shot4hitUFO()
                    End If
                Next
                If Shot4.Top < 0 Then
                    Shot4.Hide()
                    fire4 = False
                    Shot4.Location = ResetShot.Location
                End If
            End If
            If fire5 = True Then
                Shot5.Top = Shot5.Top - shotspeed
                For i = 0 To 49
                    If Shot5.Bounds.IntersectsWith(aliens(i).Bounds) Then
                        Alienhit = i
                        Shot5hit()
                    ElseIf Shot5.Bounds.IntersectsWith(UFO.Bounds) Then
                        shot5hitUFO()
                    End If
                Next
                If Shot5.Top < 0 Then
                    Shot5.Hide()
                    fire5 = False
                    Shot5.Location = ResetShot.Location
                End If
            End If
        End If
    End Sub

    Private Sub Shot1hit()
        Shot1.Hide()
        If sfxon = True Then
            InvaderKilledSfx.Play()
        End If
        fire1 = False
        Shot1.Location = ResetShot.Location
        aliens(Alienhit).Top = aliens(Alienhit).Top + 10000
        kills = kills + 1
        Try
            score = score + ((level * (SettingsDifficultylvl.Value / 5)) * SettingsGamePace.Value)
        Catch ex As Exception
            score = score + level
        End Try

        If kills = 50 Then
            Levelcomplete()
        End If
    End Sub
    Private Sub Shot2hit()
        Shot2.Hide()
        If sfxon = True Then
            InvaderKilledSfx.Play()
        End If
        fire2 = False
        Shot2.Location = ResetShot.Location
        aliens(Alienhit).Top = aliens(Alienhit).Top + 10000
        kills = kills + 1
        Try
            score = score + ((level * (SettingsDifficultylvl.Value / 5)) * SettingsGamePace.Value)
        Catch ex As Exception
            score = score + level
        End Try
        If kills = 50 Then
            Levelcomplete()
        End If
    End Sub
    Private Sub Shot3hit()
        Shot3.Hide()
        If sfxon = True Then
            InvaderKilledSfx.Play()
        End If
        fire3 = False
        Shot3.Location = ResetShot.Location
        aliens(Alienhit).Top = aliens(Alienhit).Top + 10000
        kills = kills + 1
        Try
            score = score + ((level * (SettingsDifficultylvl.Value / 5)) * SettingsGamePace.Value)
        Catch ex As Exception
            score = score + level
        End Try
        If kills = 50 Then
            Levelcomplete()
        End If
    End Sub
    Private Sub Shot4hit()
        Shot4.Hide()
        If sfxon = True Then
            InvaderKilledSfx.Play()
        End If
        fire4 = False
        Shot4.Location = ResetShot.Location
        aliens(Alienhit).Top = aliens(Alienhit).Top + 10000
        kills = kills + 1
        Try
            score = score + ((level * (SettingsDifficultylvl.Value / 5)) * SettingsGamePace.Value)
        Catch ex As Exception
            score = score + level
        End Try
        If kills = 50 Then
            Levelcomplete()
        End If
    End Sub
    Private Sub Shot5hit()
        Shot5.Hide()
        If sfxon = True Then
            InvaderKilledSfx.Play()
        End If
        fire5 = False
        Shot5.Location = ResetShot.Location
        aliens(Alienhit).Top = aliens(Alienhit).Top + 10000
        kills = kills + 1
        Try
            score = score + ((level * (SettingsDifficultylvl.Value / 5)) * SettingsGamePace.Value)
        Catch ex As Exception
            score = score + level
        End Try
        If kills = 50 Then
            Levelcomplete()
        End If
    End Sub
    Private Sub Levelcomplete()
        leveldone.Visible = True
        leveldone.Text = "Level " & level & " Complete"
        AlienMover.Interval = 1000 / SettingsGamePace.Value
        level = level + 1
        kills = 0
        For i = 0 To 49
            aliens(i).Location = alienstartlocation(i)
        Next
        InitializeAShotPosition()
        If AlienMover.Interval < 500 Then
            If AShotChance > 100 * level Then
                AShotChance = AShotChance - (100 * level)
            End If
        ElseIf SettingsDifficultylvl.Value > 5 Then
            If AlienMover.Interval > 50 * level Then
                AlienMover.Interval = AlienMover.Interval - 50 * level
            End If
        Else
            AlienMover.Interval = AlienMover.Interval - 50
        End If
    End Sub

    Private Sub Highscoresdisp_Click(sender As Object, e As EventArgs) Handles Highscoresdisp.Click
        Title.Hide()
        instructions1.Hide()
        instructions2.Hide()
        instructions3.Hide()
        instructions4.Hide()
        instructions5.Hide()
        instructions6.Hide()
        Controlsbox.Hide()
        SettingsButton.Hide()
        Back.Show()
        StartAlien.Hide()
        StartShip.Hide()
        StartButton.Hide()
        QuitButton.Hide()
        Highscoresdisp.Hide()
        Highscoreslist.Show()
        Dim currentline As String
        Dim splitrecord() As String
        Dim arrayelements As Integer
        Dim holdingname As String
        Dim holdingscore As Integer
        Dim namearr(100) As String
        Dim scorearr(100) As Integer
        Dim count As Integer = 0

        FileOpen(1, "Highscores.txt", OpenMode.Input)
        Do Until EOF(1) = True
            currentline = LineInput(1)
            splitrecord = currentline.Split(":")
            namearr(count) = splitrecord(0)
            Try
                scorearr(count) = splitrecord(1)
            Catch ex As Exception
                count = count - 1
            End Try

            count = count + 1

        Loop
        FileClose(1)
        arrayelements = count - 2
        For i = 0 To arrayelements

            For j = 0 To arrayelements
                If scorearr(j + 1) > scorearr(j) Then
                    holdingscore = scorearr(j)
                    holdingname = namearr(j)
                    scorearr(j) = scorearr(j + 1)
                    namearr(j) = namearr(j + 1)
                    scorearr(j + 1) = holdingscore
                    namearr(j + 1) = holdingname


                End If
            Next
        Next
        Highscoreslist.Text = "HIGHSCORES: " & Chr(13) & Chr(13)
        If count < 10 Then
            For i = 0 To count - 1

                Highscoreslist.Text = Highscoreslist.Text & (i + 1)

                Highscoreslist.Text = Highscoreslist.Text & ". " & namearr(i) & ": " & scorearr(i) & Chr(13)
            Next
        Else
            For i = 0 To 9
                Highscoreslist.Text = Highscoreslist.Text & (i + 1)

                Highscoreslist.Text = Highscoreslist.Text & ". " & namearr(i) & ": " & scorearr(i) & Chr(13)
            Next

        End If


    End Sub

    Private Sub Back_Click(sender As Object, e As EventArgs) Handles Back.Click
        Title.Show()
        SettingsButton.Show()
        instructions1.Show()
        instructions2.Show()
        instructions3.Show()
        instructions4.Show()
        instructions5.Show()
        instructions6.Show()
        Controlsbox.Show()
        StartAlien.Show()
        StartShip.Show()
        StartButton.Show()
        QuitButton.Show()
        Highscoresdisp.Show()
        Highscoreslist.Hide()
        Highscoreslist.Text = ""
        Back.Hide()
        SettingsButton.Show()

    End Sub

    Private Sub droppowerup()
        Randomize()
        Dim chance As Integer
        chance = Int((100 - 0) * Rnd() + 0)
        Dim checker As Integer
        checker = Int((chance - 0) * Rnd() + 0)

        Dim rndalien As Integer
        If checker > 92 And speedpowerupdrop = False Then

            rndalien = Int((49 - 0) * Rnd() + 0)
            SpeedPowerup.Location = aliens(rndalien).Location
            speedpowerupdrop = True
            SpeedPowerup.Visible = True
        End If
        Randomize()
        chance = Int((100 - 0) * Rnd() + 0)
        checker = Int((chance - 0) * Rnd() + 0)
        If checker > 93 And multishotdrop = False Then
            rndalien = Int((49 - 0) * Rnd() + 0)
            MissilePowerUp.Location = aliens(rndalien).Location
            multishotdrop = True
            MissilePowerUp.Visible = True
        End If
        Randomize()
        chance = Int((100 - 0) * Rnd() + 0)
        checker = Int((chance - 0) * Rnd() + 0)
        If checker > 94 And shielddrop = False Then
            rndalien = Int((49 - 0) * Rnd() + 0)
            ShieldPowerup.Location = aliens(rndalien).Location
            shielddrop = True
            ShieldPowerup.Visible = True
        End If
    End Sub


    Private Sub AlienMover_Tick(sender As Object, e As EventArgs) Handles AlienMover.Tick
        movealiens()
        MoveAlienShots()
        activateUFO()
        If deathstart = True Then
            deathtimecount = deathtimecount + 1
            LifeLost()

            If deathtimecount > 2 Then
                deathtimecount = 0
            End If
        End If
        If AlienMover.Interval > 100 Then
            If kills > 48 Then
                AlienMover.Interval = (1000 / SettingsGamePace.Value) - 900
                Exit Sub
            ElseIf kills > 45 Then
                AlienMover.Interval = (1000 / SettingsGamePace.Value) - 800
                Exit Sub
            ElseIf kills > 40 Then
                AlienMover.Interval = (1000 / SettingsGamePace.Value) - 700
                Exit Sub
            ElseIf kills > 35 Then
                AlienMover.Interval = (1000 / SettingsGamePace.Value) - 600
                Exit Sub
            ElseIf kills > 30 Then
                AlienMover.Interval = (1000 / SettingsGamePace.Value) - 500
                Exit Sub
            ElseIf kills > 25 Then
                AlienMover.Interval = (1000 / SettingsGamePace.Value) - 400
                Exit Sub
            ElseIf kills > 20 Then
                AlienMover.Interval = (1000 / SettingsGamePace.Value) - 300

                Exit Sub
            ElseIf kills > 15 Then
                AlienMover.Interval = (1000 / SettingsGamePace.Value) - 200

                Exit Sub
            ElseIf kills > 10 Then
                AlienMover.Interval = (1000 / SettingsGamePace.Value) - 100
                Exit Sub
            Else
                AlienMover.Interval = (1000 / SettingsGamePace.Value)
            End If
        End If
    End Sub

    Private Sub LoadAlienShots()
        AlienShotLbls(0) = AShot1
        AlienShotLbls(1) = AShot2
        AlienShotLbls(2) = Ashot3
        AlienShotLbls(3) = AShot4
        AlienShotLbls(4) = AShot5
        AlienShotLbls(5) = AShot6
        AlienShotLbls(6) = AShot7
        AlienShotLbls(7) = Ashot8
        AlienShotLbls(8) = AShot9
        AlienShotLbls(9) = AShot10
        AlienShotLbls(10) = AShot11
        AlienShotLbls(11) = AShot12
        AlienShotLbls(12) = AShot13
        AlienShotLbls(13) = AShot14
        AlienShotLbls(14) = AShot15
        AlienShotLbls(15) = AShot16
        AlienShotLbls(16) = AShot17
        AlienShotLbls(17) = AShot18
        AlienShotLbls(18) = AShot19
        AlienShotLbls(19) = AShot20
        AlienShotLbls(20) = AShot21
        AlienShotLbls(21) = AShot22
        AlienShotLbls(22) = AShot23
        AlienShotLbls(23) = AShot24
        AlienShotLbls(24) = AShot25
        AlienShotLbls(25) = AShot26
        AlienShotLbls(26) = AShot27
        AlienShotLbls(27) = AShot28
        AlienShotLbls(28) = AShot29
        AlienShotLbls(29) = AShot30
        AlienShotLbls(30) = AShot31
        AlienShotLbls(31) = AShot32
        AlienShotLbls(32) = AShot33
        AlienShotLbls(33) = AShot34
        AlienShotLbls(34) = AShot35
        AlienShotLbls(35) = AShot36
        AlienShotLbls(36) = AShot37
        AlienShotLbls(37) = AShot38
        AlienShotLbls(38) = AShot39
        AlienShotLbls(39) = AShot40
        AlienShotLbls(40) = AShot41
        AlienShotLbls(41) = AShot42
        AlienShotLbls(42) = AShot43
        AlienShotLbls(43) = AShot44
        AlienShotLbls(44) = AShot45
        AlienShotLbls(45) = AShot46
        AlienShotLbls(46) = AShot47
        AlienShotLbls(47) = AShot48
        AlienShotLbls(48) = AShot49
        AlienShotLbls(49) = AShot50
    End Sub
    Private Sub InitializeAShotPosition()
        For i = 0 To 49
            AlienShotLbls(i).Left = aliens(i).Left + 22
            AlienShotLbls(i).Top = aliens(i).Top + 43
            AlienShots(i) = False
            AlienShotLbls(i).Hide()
        Next
    End Sub
    Private Sub MoveAlienShots()
        Randomize()
        For i = 0 To 49
            If AlienShots(i) = False Then
                ran = CInt(Int(AShotChance * Rnd()) + 1)
                If ran = AShotChance Then
                    If aliens(i).Top < Me.Height Then
                        AlienShots(i) = True
                        AlienShotLbls(i).Show()
                    End If
                End If
            End If
        Next

        For i = 0 To 49
            If AlienShots(i) = True Then
                AlienShotLbls(i).Top = AlienShotLbls(i).Top + 2
                If AlienShotLbls(i).Bounds.IntersectsWith(Ship.Bounds) Then
                    If shieldactive = False Then
                        AlienShotLbls(i).Hide()
                        AlienShotLbls(i).Location = aliens(i).Location
                        AlienShotLbls(i).Left = aliens(i).Left + 22
                        AlienShotLbls(i).Top = aliens(i).Top + 43
                        LifeLost()
                    Else
                        Shield.Image = My.Resources.shieldhit
                        AlienShots(i) = False
                        AlienShotLbls(i).Hide()
                        AlienShotLbls(i).Location = aliens(i).Location
                        AlienShotLbls(i).Left = aliens(i).Left + 22
                        AlienShotLbls(i).Top = aliens(i).Top + 43
                    End If

                End If
                If AlienShotLbls(i).Top > Me.Height + 100 Then
                    AlienShots(i) = False
                    AlienShotLbls(i).Hide()
                    AlienShotLbls(i).Location = aliens(i).Location
                    AlienShotLbls(i).Left = aliens(i).Left + 22
                    AlienShotLbls(i).Top = aliens(i).Top + 43

                End If
            End If
        Next
    End Sub


    Private Sub ShieldTimer_Tick(sender As Object, e As EventArgs) Handles ShieldTimer.Tick
        If shieldactive = True Then
            If Shield.Image.Tag = My.Resources.shieldhit.Tag Then
                Shield.Image = My.Resources.shield
            End If

        End If
    End Sub

    Private Sub MoveUFO()
        Dim rndchance
        UFOShot.Show()
        If ufoMoving = True Then
            UFO.Left = UFO.Left - 3
            If ufoshooting = False Then
                UFOShot.Left = UFOShot.Left - 3
                rndchance = CInt(Int(100 * Rnd()) + 1)
                If rndchance > 50 Then
                    ufoshooting = True
                End If
            End If
        End If



    End Sub
    Private Sub shot1hitUFO()
        Shot1.Hide()
        fire1 = False
        Shot1.Location = ResetShot.Location
        UFO.Left = Me.Width + 500
        UFOShot.Left = UFO.Left + 37
        UFOShot.Top = UFO.Top + 40
        score = score + 100
        UFO.Visible = False
        ufoMoving = False
    End Sub
    Private Sub shot2hitUFO()
        Shot1.Hide()
        fire2 = False
        Shot2.Location = ResetShot.Location
        UFO.Left = Me.Width + 500
        UFOShot.Left = UFO.Left + 37
        UFOShot.Top = UFO.Top + 40
        score = score + 100
        UFO.Visible = False
        ufoMoving = False
    End Sub
    Private Sub shot3hitUFO()
        Shot3.Hide()
        fire3 = False
        Shot3.Location = ResetShot.Location
        UFO.Left = Me.Width + 500
        UFOShot.Left = UFO.Left + 37
        UFOShot.Top = UFO.Top + 40
        score = score + 100
        UFO.Visible = False
        ufoMoving = False
    End Sub
    Private Sub shot4hitUFO()
        Shot4.Hide()
        fire4 = False
        Shot4.Location = ResetShot.Location
        UFO.Left = Me.Width + 500
        UFOShot.Left = UFO.Left + 37
        UFOShot.Top = UFO.Top + 40
        score = score + 100
        UFO.Visible = False
        ufoMoving = False
    End Sub
    Private Sub shot5hitUFO()
        Shot5.Hide()
        fire5 = False
        Shot5.Location = ResetShot.Location
        UFO.Left = Me.Width + 500
        UFOShot.Left = UFO.Left + 37
        UFOShot.Top = UFO.Top + 40
        score = score + 100
        UFO.Visible = False
        ufoMoving = False
    End Sub
    Private Sub activateUFO()
        Randomize()
        Dim chance As Integer
        chance = Int((100 - 0) * Rnd() + 0)
        Dim checker As Integer
        checker = Int((chance - 0) * Rnd() + 0)

        If checker > 80 And ufoMoving = False Then
            ufoMoving = True
            UFO.Visible = True
            UFO.Image = My.Resources.UFO
        End If
        If sfxon = True Then
            UFOSfx.Play()
        End If
    End Sub

    Private Sub UFOFire()
        If UFOShot.Top > Me.Height Then
            ufoshooting = False
            UFOShot.Hide()
            UFOShot.Left = UFO.Left + 37
            UFOShot.Top = UFO.Top + 40
        End If

        If ufoshooting = True Then
            UFOShot.Show()
            UFOShot.Top = UFOShot.Top + 5
            If UFOShot.Bounds.IntersectsWith(Ship.Bounds) Then
                If shieldactive = False Then
                    UFOShot.Hide()
                    UFOShot.Left = UFO.Left + 37
                    UFOShot.Top = UFO.Top + 40
                    LifeLost()
                Else
                    UFOShot.Hide()
                    UFOShot.Left = UFO.Left + 37
                    UFOShot.Top = UFO.Top + 40
                    shieldactive = False
                    Shield.Hide()
                    ufoshooting = False

                End If

            End If
        End If
    End Sub

    Private Sub PowerUpTimersactivator()
        If shieldactive = False Then
            ShieldTimerimage.Hide()
            ShieldTimerlbl.Hide()
        ElseIf shieldactive = True Then
            ShieldTimerimage.Show()
            ShieldTimerlbl.Show()
            ShieldTimerlbl.Text = shieldtime / 1000
        End If
        If speedactivate = False Then
            SpeedupImage.Hide()
            SpeedupTimerlbl.Hide()
        ElseIf speedactivate = True Then
            SpeedupImage.Show()
            SpeedupTimerlbl.Show()
            SpeedupTimerlbl.Text = speedpowertime / 1000
        End If
        If multishotactive = False Then
            Multishotimage.Hide()
            MultishotTimerlbl.Hide()
        ElseIf multishotactive = True Then
            Multishotimage.Show()
            MultishotTimerlbl.Show()
            MultishotTimerlbl.Text = multishottime / 1000
        End If
    End Sub

    Private Sub LifeLost()
        If deathstart = True Then
            If deathtimecount = 2 Then
                Mover.Start()
                shieldactive = False
                speedactivate = False
                multishotactive = False
                InitializeAShotPosition()

                Ship.Image = My.Resources.ship
                Ship.Location = shipstartpos
                ResetShot.Location = shipshotstartpos
                Shot1.Location = ResetShot.Location
                Shot2.Location = ResetShot.Location
                Shot3.Location = ResetShot.Location
                Shot4.Location = ResetShot.Location
                Shot5.Location = ResetShot.Location
                deathstart = False
            End If
        Else
            If sfxon = True Then
                playerdeathsfx.Play()
            End If
            If lives = 3 Then
                lives = lives - 1
                Mover.Stop()
                Life3.Hide()
                shieldactive = False
                shieldtime = 7500
                speedactivate = False
                speedpowertime = 10000
                multishotactive = False
                multishottime = 10000
                Ship.Image = My.Resources.Fire_Explosion_PNG_Picture_Clipart
                deathstart = True
            ElseIf lives = 2 Then
                lives = lives - 1
                Mover.Stop()
                Life3.Hide()
                Life2.Hide()
                shieldactive = False
                shieldtime = 7500
                speedactivate = False
                speedpowertime = 10000
                multishotactive = False
                multishottime = 10000
                Ship.Image = My.Resources.Fire_Explosion_PNG_Picture_Clipart
                deathstart = True
            ElseIf lives = 1 Then
                lives = lives - 1
                Mover.Stop()
                Life3.Hide()
                Life2.Hide()
                Life1.Hide()
                shieldactive = False
                shieldtime = 7500
                speedactivate = False
                speedpowertime = 10000
                multishotactive = False
                multishottime = 10000
                playerDied()

            End If
        End If

    End Sub

    Private Sub SettingsButton_Click(sender As Object, e As EventArgs) Handles SettingsButton.Click
        Settingspanel.BringToFront()
        Settingspanel.Show()

    End Sub

    Private Sub SettingsMusic_CheckedChanged(sender As Object, e As EventArgs) Handles SettingsMusic.CheckedChanged
        If SettingsMusic.Checked = True Then
            sfxon = False
            ThemeSong.PlayLooping()
        ElseIf SettingsMusic.Checked = False Then
            My.Computer.Audio.Stop()
        End If

    End Sub

    Private Sub SettingsSFX_CheckedChanged(sender As Object, e As EventArgs) Handles SettingsSFX.CheckedChanged
        If SettingsSFX.Checked = True Then
            sfxon = True
            My.Computer.Audio.Stop()
        ElseIf SettingsSFX.Checked = False Then
            sfxon = False
        End If
    End Sub

    Private Sub SettingsSave_Click(sender As Object, e As EventArgs) Handles SettingsSave.Click
        Settingspanel.Hide()
        FileOpen(1, "Settings.txt", OpenMode.Output)
        PrintLine(1, SettingsMusic.Checked)
        PrintLine(1, SettingsSFX.Checked)
        PrintLine(1, SettingsDifficultylvl.Value)
        PrintLine(1, SettingsGamePace.Value)
        PrintLine(1, BGPicker.Color.ToString)
        FileClose(1)
    End Sub


    Private Sub ClearHighscoresbtn_Click(sender As Object, e As EventArgs) Handles ClearHighscoresbtn.Click
        If MsgBox("Warning! This Cannot be reversed" & Chr(13) & "Are You Sure?", MsgBoxStyle.YesNoCancel, "WARNING") = MsgBoxResult.Yes Then
            FileOpen(1, "Highscores.txt", OpenMode.Output)
            While EOF(1) = False
                PrintLine(1, "")
            End While
            FileClose(1)
        End If
    End Sub

    Private Sub BGColourbtn_Click(sender As Object, e As EventArgs) Handles BGColourbtn.Click

        If BGPicker.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            colour = BGPicker.Color
            Me.BackColor = colour
            SettingsDifficultylvl.BackColor = colour
            SettingsGamePace.BackColor = colour
        End If
    End Sub

    Private Sub SettingsDifficultylvl_Scroll(sender As Object, e As EventArgs) Handles SettingsDifficultylvl.Scroll
        Difficultylbl.Text = "Difficulty: " & SettingsDifficultylvl.Value
        If SettingsDifficultylvl.Value = 0 Then
            AShotChance = 0
        ElseIf SettingsDifficultylvl.Value = 1 Then
            AShotChance = 9000
        ElseIf SettingsDifficultylvl.Value = 2 Then
            AShotChance = 8000
        ElseIf SettingsDifficultylvl.Value = 3 Then
            AShotChance = 7000
        ElseIf SettingsDifficultylvl.Value = 4 Then
            AShotChance = 6000
        ElseIf SettingsDifficultylvl.Value = 5 Then
            AShotChance = 4000
        ElseIf SettingsDifficultylvl.Value = 6 Then
            AShotChance = 3500
        ElseIf SettingsDifficultylvl.Value = 7 Then
            AShotChance = 3000
        ElseIf SettingsDifficultylvl.Value = 8 Then
            AShotChance = 2500
        ElseIf SettingsDifficultylvl.Value = 9 Then
            AShotChance = 2000
        ElseIf SettingsDifficultylvl.Value = 10 Then
            AShotChance = 1000
        End If
    End Sub

    Private Sub Settingsgamepace_Scroll(sender As Object, e As EventArgs) Handles SettingsGamePace.Scroll
        Gamepacelbl.Text = "Game Pace:" & SettingsGamePace.Value & "x Speed"
        AlienMover.Interval = 1000 / SettingsGamePace.Value
    End Sub

    Private Sub SettingsGameMechanics_Click(sender As Object, e As EventArgs) Handles SettingsGameMechanics.Click
        Mechanicspanel.BringToFront()
        Mechanicspanel.Show()
    End Sub

    Private Sub Closemechbtn_Click(sender As Object, e As EventArgs) Handles Closemechbtn.Click
        Mechanicspanel.SendToBack()
        Mechanicspanel.Hide()
    End Sub

    Private Sub next1_Click(sender As Object, e As EventArgs) Handles Next1.Click

        MechanicsPanel2.Show()
        MechanicsPanel2.BringToFront()
        Mechanicspanel.Hide()
        Mechanicspanel.SendToBack()

    End Sub

    Private Sub Close2_Click(sender As Object, e As EventArgs) Handles Close2.Click
        MechanicsPanel2.Hide()
        MechanicsPanel2.SendToBack()
    End Sub

    Private Sub PauseTimer_Tick(sender As Object, e As EventArgs) Handles PauseTimer.Tick
        Dim colours(22) As System.Drawing.Color
        Dim rand As Integer

        colours(0) = Color.AliceBlue
        colours(1) = Color.AntiqueWhite
        colours(2) = Color.Aqua
        colours(3) = Color.Aquamarine
        colours(4) = Color.Azure
        colours(5) = Color.Beige
        colours(6) = Color.Bisque
        colours(7) = Color.BlanchedAlmond
        colours(8) = Color.Blue
        colours(9) = Color.BlueViolet
        colours(10) = Color.Chocolate
        colours(11) = Color.DarkCyan
        colours(12) = Color.DarkRed
        colours(13) = Color.Firebrick
        colours(14) = Color.ForestGreen
        colours(15) = Color.HotPink
        colours(16) = Color.Lavender
        colours(17) = Color.PeachPuff
        colours(18) = Color.Maroon
        colours(19) = Color.Magenta
        colours(20) = Color.SkyBlue
        colours(21) = Color.WhiteSmoke
        colours(22) = Color.Cyan

        Randomize()
        rand = Int(((22 - 0) * Rnd() - 0) + 1)
        Pauselbl.ForeColor = colours(rand)

        If Pauselbl.Visible = True Then
            Pauselbl.Visible = False
        Else
            Pauselbl.Visible = True
        End If
    End Sub
End Class
