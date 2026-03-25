namespace cours6
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            tabControl = new TabControl();
            tabExercice1 = new TabPage();
            lblDomaine = new Label();
            txtDomaine = new TextBox();
            btnRechercher = new Button();
            dgvClients = new DataGridView();
            tabExercice2 = new TabPage();
            lblClientId = new Label();
            txtClientId = new TextBox();
            lblMontant = new Label();
            txtMontant = new TextBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            btnAjouterCommande = new Button();
            lblStatutTransaction = new Label();
            dgvCommandes = new DataGridView();
            tabExercice3 = new TabPage();
            lblEx3Info = new Label();
            btnChargerDataSet = new Button();
            lblClientIdEx3 = new Label();
            txtClientIdEx3 = new TextBox();
            lblNouveauNom = new Label();
            txtNouveauNom = new TextBox();
            btnModifierClient = new Button();
            lblNomNouveau = new Label();
            txtNomNouveau = new TextBox();
            lblEmailNouveau = new Label();
            txtEmailNouveau = new TextBox();
            lblSoldeNouveau = new Label();
            txtSoldeNouveau = new TextBox();
            btnAjouterClient = new Button();
            dgvDataSet = new DataGridView();
            btnSynchroniser = new Button();
            btnRafraichir = new Button();
            lblStatutDataSet = new Label();
            tabExercice4 = new TabPage();
            lblEx4Info = new Label();
            btnChargerRelations = new Button();
            trvClients = new TreeView();
            dgvCommandesDetail = new DataGridView();
            lblStatutRelation = new Label();
            tabExercice5 = new TabPage();
            lblEx5Clients = new Label();
            txtEx5Nom = new TextBox();
            lblEx5Email = new Label();
            txtEx5Email = new TextBox();
            lblEx5Solde = new Label();
            txtEx5Solde = new TextBox();
            btnEx5AddClient = new Button();
            btnEx5UpdateClient = new Button();
            btnEx5DeleteClient = new Button();
            dgvEx5Clients = new DataGridView();
            lblEx5Commandes = new Label();
            lblEx5Montant = new Label();
            txtEx5Montant = new TextBox();
            lblEx5DescriptionCommande = new Label();
            txtEx5Description = new TextBox();
            btnEx5AddCommande = new Button();
            btnEx5UpdateCommande = new Button();
            btnEx5DeleteCommande = new Button();
            dgvEx5Commandes = new DataGridView();
            lblStatutEx5 = new Label();
            tabControl.SuspendLayout();
            tabExercice1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClients).BeginInit();
            tabExercice2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCommandes).BeginInit();
            tabExercice3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDataSet).BeginInit();
            tabExercice4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCommandesDetail).BeginInit();
            tabExercice5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEx5Clients).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEx5Commandes).BeginInit();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabExercice1);
            tabControl.Controls.Add(tabExercice2);
            tabControl.Controls.Add(tabExercice3);
            tabControl.Controls.Add(tabExercice4);
            tabControl.Controls.Add(tabExercice5);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(800, 500);
            tabControl.TabIndex = 0;
            // 
            // tabExercice1
            // 
            tabExercice1.Controls.Add(lblDomaine);
            tabExercice1.Controls.Add(txtDomaine);
            tabExercice1.Controls.Add(btnRechercher);
            tabExercice1.Controls.Add(dgvClients);
            tabExercice1.Location = new Point(4, 29);
            tabExercice1.Name = "tabExercice1";
            tabExercice1.Padding = new Padding(3);
            tabExercice1.Size = new Size(792, 467);
            tabExercice1.TabIndex = 0;
            tabExercice1.Text = "Exercice 1 - Lecture filtrée";
            tabExercice1.UseVisualStyleBackColor = true;
            // 
            // lblDomaine
            // 
            lblDomaine.Location = new Point(12, 12);
            lblDomaine.Name = "lblDomaine";
            lblDomaine.Size = new Size(300, 20);
            lblDomaine.TabIndex = 0;
            lblDomaine.Text = "Domaine de courriel (ex. @gmail.com):";
            // 
            // txtDomaine
            // 
            txtDomaine.Location = new Point(12, 35);
            txtDomaine.Name = "txtDomaine";
            txtDomaine.Size = new Size(300, 27);
            txtDomaine.TabIndex = 1;
            txtDomaine.Text = "@gmail.com";
            // 
            // btnRechercher
            // 
            btnRechercher.Location = new Point(320, 35);
            btnRechercher.Name = "btnRechercher";
            btnRechercher.Size = new Size(100, 27);
            btnRechercher.TabIndex = 2;
            btnRechercher.Text = "Rechercher";
            btnRechercher.Click += ButtonRechercher_Click;
            // 
            // dgvClients
            // 
            dgvClients.AllowUserToAddRows = false;
            dgvClients.ColumnHeadersHeight = 29;
            dgvClients.Location = new Point(12, 70);
            dgvClients.Name = "dgvClients";
            dgvClients.RowHeadersWidth = 51;
            dgvClients.Size = new Size(760, 380);
            dgvClients.TabIndex = 3;
            // 
            // tabExercice2
            // 
            tabExercice2.Controls.Add(lblClientId);
            tabExercice2.Controls.Add(txtClientId);
            tabExercice2.Controls.Add(lblMontant);
            tabExercice2.Controls.Add(txtMontant);
            tabExercice2.Controls.Add(lblDescription);
            tabExercice2.Controls.Add(txtDescription);
            tabExercice2.Controls.Add(btnAjouterCommande);
            tabExercice2.Controls.Add(lblStatutTransaction);
            tabExercice2.Controls.Add(dgvCommandes);
            tabExercice2.Location = new Point(4, 29);
            tabExercice2.Name = "tabExercice2";
            tabExercice2.Padding = new Padding(3);
            tabExercice2.Size = new Size(792, 467);
            tabExercice2.TabIndex = 1;
            tabExercice2.Text = "Exercice 2 - Transaction";
            tabExercice2.UseVisualStyleBackColor = true;
            // 
            // lblClientId
            // 
            lblClientId.Location = new Point(12, 12);
            lblClientId.Name = "lblClientId";
            lblClientId.Size = new Size(100, 20);
            lblClientId.TabIndex = 0;
            lblClientId.Text = "ID Client:";
            // 
            // txtClientId
            // 
            txtClientId.Location = new Point(120, 12);
            txtClientId.Name = "txtClientId";
            txtClientId.Size = new Size(80, 27);
            txtClientId.TabIndex = 1;
            // 
            // lblMontant
            // 
            lblMontant.Location = new Point(12, 50);
            lblMontant.Name = "lblMontant";
            lblMontant.Size = new Size(100, 20);
            lblMontant.TabIndex = 2;
            lblMontant.Text = "Montant commande:";
            // 
            // txtMontant
            // 
            txtMontant.Location = new Point(120, 50);
            txtMontant.Name = "txtMontant";
            txtMontant.Size = new Size(80, 27);
            txtMontant.TabIndex = 3;
            // 
            // lblDescription
            // 
            lblDescription.Location = new Point(220, 12);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(100, 20);
            lblDescription.TabIndex = 4;
            lblDescription.Text = "Description:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(330, 12);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(200, 27);
            txtDescription.TabIndex = 5;
            // 
            // btnAjouterCommande
            // 
            btnAjouterCommande.Location = new Point(536, 12);
            btnAjouterCommande.Name = "btnAjouterCommande";
            btnAjouterCommande.Size = new Size(130, 27);
            btnAjouterCommande.TabIndex = 6;
            btnAjouterCommande.Text = "Ajouter Commande";
            btnAjouterCommande.Click += ButtonAjouterCommande_Click;
            // 
            // lblStatutTransaction
            // 
            lblStatutTransaction.Location = new Point(12, 90);
            lblStatutTransaction.Name = "lblStatutTransaction";
            lblStatutTransaction.Size = new Size(760, 20);
            lblStatutTransaction.TabIndex = 7;
            lblStatutTransaction.Text = "Statut: En attente...";
            // 
            // dgvCommandes
            // 
            dgvCommandes.AllowUserToAddRows = false;
            dgvCommandes.ColumnHeadersHeight = 29;
            dgvCommandes.Location = new Point(12, 115);
            dgvCommandes.Name = "dgvCommandes";
            dgvCommandes.RowHeadersWidth = 51;
            dgvCommandes.Size = new Size(760, 335);
            dgvCommandes.TabIndex = 8;
            // 
            // tabExercice3
            // 
            tabExercice3.Controls.Add(lblEx3Info);
            tabExercice3.Controls.Add(btnChargerDataSet);
            tabExercice3.Controls.Add(lblClientIdEx3);
            tabExercice3.Controls.Add(txtClientIdEx3);
            tabExercice3.Controls.Add(lblNouveauNom);
            tabExercice3.Controls.Add(txtNouveauNom);
            tabExercice3.Controls.Add(btnModifierClient);
            tabExercice3.Controls.Add(lblNomNouveau);
            tabExercice3.Controls.Add(txtNomNouveau);
            tabExercice3.Controls.Add(lblEmailNouveau);
            tabExercice3.Controls.Add(txtEmailNouveau);
            tabExercice3.Controls.Add(lblSoldeNouveau);
            tabExercice3.Controls.Add(txtSoldeNouveau);
            tabExercice3.Controls.Add(btnAjouterClient);
            tabExercice3.Controls.Add(dgvDataSet);
            tabExercice3.Controls.Add(btnSynchroniser);
            tabExercice3.Controls.Add(btnRafraichir);
            tabExercice3.Controls.Add(lblStatutDataSet);
            tabExercice3.Location = new Point(4, 29);
            tabExercice3.Name = "tabExercice3";
            tabExercice3.Padding = new Padding(3);
            tabExercice3.Size = new Size(792, 467);
            tabExercice3.TabIndex = 2;
            tabExercice3.Text = "Exercice 3 - DataSet";
            tabExercice3.UseVisualStyleBackColor = true;
            // 
            // lblEx3Info
            // 
            lblEx3Info.Location = new Point(12, 12);
            lblEx3Info.Name = "lblEx3Info";
            lblEx3Info.Size = new Size(200, 20);
            lblEx3Info.TabIndex = 0;
            lblEx3Info.Text = "Mode déconnecté avec DataSet:";
            // 
            // btnChargerDataSet
            // 
            btnChargerDataSet.Location = new Point(182, 9);
            btnChargerDataSet.Name = "btnChargerDataSet";
            btnChargerDataSet.Size = new Size(120, 27);
            btnChargerDataSet.TabIndex = 1;
            btnChargerDataSet.Text = "Charger DataSet";
            btnChargerDataSet.Click += ButtonChargerDataSet_Click;
            // 
            // lblClientIdEx3
            // 
            lblClientIdEx3.Location = new Point(12, 50);
            lblClientIdEx3.Name = "lblClientIdEx3";
            lblClientIdEx3.Size = new Size(80, 20);
            lblClientIdEx3.TabIndex = 2;
            lblClientIdEx3.Text = "ID Client:";
            // 
            // txtClientIdEx3
            // 
            txtClientIdEx3.Location = new Point(100, 50);
            txtClientIdEx3.Name = "txtClientIdEx3";
            txtClientIdEx3.Size = new Size(60, 27);
            txtClientIdEx3.TabIndex = 3;
            // 
            // lblNouveauNom
            // 
            lblNouveauNom.Location = new Point(170, 50);
            lblNouveauNom.Name = "lblNouveauNom";
            lblNouveauNom.Size = new Size(111, 27);
            lblNouveauNom.TabIndex = 4;
            lblNouveauNom.Text = "Nouveau nom:";
            // 
            // txtNouveauNom
            // 
            txtNouveauNom.Location = new Point(300, 50);
            txtNouveauNom.Name = "txtNouveauNom";
            txtNouveauNom.Size = new Size(120, 27);
            txtNouveauNom.TabIndex = 5;
            // 
            // btnModifierClient
            // 
            btnModifierClient.Location = new Point(426, 47);
            btnModifierClient.Name = "btnModifierClient";
            btnModifierClient.Size = new Size(100, 27);
            btnModifierClient.TabIndex = 6;
            btnModifierClient.Text = "Modifier";
            btnModifierClient.Click += ButtonModifierClient_Click;
            // 
            // lblNomNouveau
            // 
            lblNomNouveau.Location = new Point(12, 90);
            lblNomNouveau.Name = "lblNomNouveau";
            lblNomNouveau.Size = new Size(80, 20);
            lblNomNouveau.TabIndex = 7;
            lblNomNouveau.Text = "Nom:";
            // 
            // txtNomNouveau
            // 
            txtNomNouveau.Location = new Point(100, 90);
            txtNomNouveau.Name = "txtNomNouveau";
            txtNomNouveau.Size = new Size(120, 27);
            txtNomNouveau.TabIndex = 8;
            // 
            // lblEmailNouveau
            // 
            lblEmailNouveau.Location = new Point(230, 90);
            lblEmailNouveau.Name = "lblEmailNouveau";
            lblEmailNouveau.Size = new Size(60, 20);
            lblEmailNouveau.TabIndex = 9;
            lblEmailNouveau.Text = "Email:";
            // 
            // txtEmailNouveau
            // 
            txtEmailNouveau.Location = new Point(300, 90);
            txtEmailNouveau.Name = "txtEmailNouveau";
            txtEmailNouveau.Size = new Size(120, 27);
            txtEmailNouveau.TabIndex = 10;
            // 
            // lblSoldeNouveau
            // 
            lblSoldeNouveau.Location = new Point(430, 90);
            lblSoldeNouveau.Name = "lblSoldeNouveau";
            lblSoldeNouveau.Size = new Size(60, 20);
            lblSoldeNouveau.TabIndex = 11;
            lblSoldeNouveau.Text = "Solde:";
            // 
            // txtSoldeNouveau
            // 
            txtSoldeNouveau.Location = new Point(500, 90);
            txtSoldeNouveau.Name = "txtSoldeNouveau";
            txtSoldeNouveau.Size = new Size(80, 27);
            txtSoldeNouveau.TabIndex = 12;
            // 
            // btnAjouterClient
            // 
            btnAjouterClient.Location = new Point(590, 90);
            btnAjouterClient.Name = "btnAjouterClient";
            btnAjouterClient.Size = new Size(100, 27);
            btnAjouterClient.TabIndex = 13;
            btnAjouterClient.Text = "Ajouter";
            btnAjouterClient.Click += ButtonAjouterClient_Click;
            // 
            // dgvDataSet
            // 
            dgvDataSet.AllowUserToAddRows = false;
            dgvDataSet.ColumnHeadersHeight = 29;
            dgvDataSet.Location = new Point(12, 130);
            dgvDataSet.Name = "dgvDataSet";
            dgvDataSet.RowHeadersWidth = 51;
            dgvDataSet.Size = new Size(760, 280);
            dgvDataSet.TabIndex = 14;
            // 
            // btnSynchroniser
            // 
            btnSynchroniser.Location = new Point(12, 420);
            btnSynchroniser.Name = "btnSynchroniser";
            btnSynchroniser.Size = new Size(120, 27);
            btnSynchroniser.TabIndex = 15;
            btnSynchroniser.Text = "Synchroniser";
            btnSynchroniser.Click += ButtonSynchroniser_Click;
            // 
            // btnRafraichir
            // 
            btnRafraichir.Location = new Point(140, 420);
            btnRafraichir.Name = "btnRafraichir";
            btnRafraichir.Size = new Size(120, 27);
            btnRafraichir.TabIndex = 16;
            btnRafraichir.Text = "Rafraîchir";
            btnRafraichir.Click += ButtonRafraichir_Click;
            // 
            // lblStatutDataSet
            // 
            lblStatutDataSet.Location = new Point(270, 420);
            lblStatutDataSet.Name = "lblStatutDataSet";
            lblStatutDataSet.Size = new Size(502, 27);
            lblStatutDataSet.TabIndex = 17;
            lblStatutDataSet.Text = "Statut: En attente...";
            // 
            // tabExercice4
            // 
            tabExercice4.Controls.Add(lblEx4Info);
            tabExercice4.Controls.Add(btnChargerRelations);
            tabExercice4.Controls.Add(trvClients);
            tabExercice4.Controls.Add(dgvCommandesDetail);
            tabExercice4.Controls.Add(lblStatutRelation);
            tabExercice4.Location = new Point(4, 29);
            tabExercice4.Name = "tabExercice4";
            tabExercice4.Padding = new Padding(3);
            tabExercice4.Size = new Size(792, 467);
            tabExercice4.TabIndex = 3;
            tabExercice4.Text = "Exercice 4 - DataRelation";
            tabExercice4.UseVisualStyleBackColor = true;
            // 
            // lblEx4Info
            // 
            lblEx4Info.Location = new Point(12, 12);
            lblEx4Info.Name = "lblEx4Info";
            lblEx4Info.Size = new Size(200, 20);
            lblEx4Info.TabIndex = 0;
            lblEx4Info.Text = "Clients et commandes (DataRelation):";
            // 
            // btnChargerRelations
            // 
            btnChargerRelations.Location = new Point(250, 12);
            btnChargerRelations.Name = "btnChargerRelations";
            btnChargerRelations.Size = new Size(150, 27);
            btnChargerRelations.TabIndex = 1;
            btnChargerRelations.Text = "Charger Relations";
            btnChargerRelations.Click += ButtonChargerRelations_Click;
            // 
            // trvClients
            // 
            trvClients.Location = new Point(12, 50);
            trvClients.Name = "trvClients";
            trvClients.Size = new Size(380, 350);
            trvClients.TabIndex = 2;
            trvClients.AfterSelect += TreeViewClients_AfterSelect;
            // 
            // dgvCommandesDetail
            // 
            dgvCommandesDetail.AllowUserToAddRows = false;
            dgvCommandesDetail.ColumnHeadersHeight = 29;
            dgvCommandesDetail.Location = new Point(400, 50);
            dgvCommandesDetail.Name = "dgvCommandesDetail";
            dgvCommandesDetail.RowHeadersWidth = 51;
            dgvCommandesDetail.Size = new Size(372, 350);
            dgvCommandesDetail.TabIndex = 3;
            // 
            // lblStatutRelation
            // 
            lblStatutRelation.Location = new Point(12, 420);
            lblStatutRelation.Name = "lblStatutRelation";
            lblStatutRelation.Size = new Size(760, 27);
            lblStatutRelation.TabIndex = 4;
            lblStatutRelation.Text = "Statut: En attente...";
            // 
            // tabExercice5
            // 
            tabExercice5.Controls.Add(lblEx5Clients);
            tabExercice5.Controls.Add(txtEx5Nom);
            tabExercice5.Controls.Add(lblEx5Email);
            tabExercice5.Controls.Add(txtEx5Email);
            tabExercice5.Controls.Add(lblEx5Solde);
            tabExercice5.Controls.Add(txtEx5Solde);
            tabExercice5.Controls.Add(btnEx5AddClient);
            tabExercice5.Controls.Add(btnEx5UpdateClient);
            tabExercice5.Controls.Add(btnEx5DeleteClient);
            tabExercice5.Controls.Add(dgvEx5Clients);
            tabExercice5.Controls.Add(lblEx5Commandes);
            tabExercice5.Controls.Add(lblEx5Montant);
            tabExercice5.Controls.Add(txtEx5Montant);
            tabExercice5.Controls.Add(lblEx5DescriptionCommande);
            tabExercice5.Controls.Add(txtEx5Description);
            tabExercice5.Controls.Add(btnEx5AddCommande);
            tabExercice5.Controls.Add(btnEx5UpdateCommande);
            tabExercice5.Controls.Add(btnEx5DeleteCommande);
            tabExercice5.Controls.Add(dgvEx5Commandes);
            tabExercice5.Controls.Add(lblStatutEx5);
            tabExercice5.Location = new Point(4, 29);
            tabExercice5.Name = "tabExercice5";
            tabExercice5.Padding = new Padding(3);
            tabExercice5.Size = new Size(792, 467);
            tabExercice5.TabIndex = 4;
            tabExercice5.Text = "Exercice 5 - CRUD Complet";
            tabExercice5.UseVisualStyleBackColor = true;
            // 
            // lblEx5Clients
            // 
            lblEx5Clients.Location = new Point(12, 12);
            lblEx5Clients.Name = "lblEx5Clients";
            lblEx5Clients.Size = new Size(100, 20);
            lblEx5Clients.TabIndex = 0;
            lblEx5Clients.Text = "Clients:";
            // 
            // txtEx5Nom
            // 
            txtEx5Nom.Location = new Point(12, 35);
            txtEx5Nom.Name = "txtEx5Nom";
            txtEx5Nom.Size = new Size(120, 27);
            txtEx5Nom.TabIndex = 1;
            // 
            // lblEx5Email
            // 
            lblEx5Email.Location = new Point(140, 35);
            lblEx5Email.Name = "lblEx5Email";
            lblEx5Email.Size = new Size(50, 20);
            lblEx5Email.TabIndex = 2;
            lblEx5Email.Text = "Email:";
            // 
            // txtEx5Email
            // 
            txtEx5Email.Location = new Point(200, 35);
            txtEx5Email.Name = "txtEx5Email";
            txtEx5Email.Size = new Size(120, 27);
            txtEx5Email.TabIndex = 3;
            // 
            // lblEx5Solde
            // 
            lblEx5Solde.Location = new Point(328, 35);
            lblEx5Solde.Name = "lblEx5Solde";
            lblEx5Solde.Size = new Size(50, 20);
            lblEx5Solde.TabIndex = 4;
            lblEx5Solde.Text = "Solde:";
            // 
            // txtEx5Solde
            // 
            txtEx5Solde.Location = new Point(388, 35);
            txtEx5Solde.Name = "txtEx5Solde";
            txtEx5Solde.Size = new Size(80, 27);
            txtEx5Solde.TabIndex = 5;
            txtEx5Solde.Text = "0";
            // 
            // btnEx5AddClient
            // 
            btnEx5AddClient.Location = new Point(476, 35);
            btnEx5AddClient.Name = "btnEx5AddClient";
            btnEx5AddClient.Size = new Size(60, 27);
            btnEx5AddClient.TabIndex = 6;
            btnEx5AddClient.Text = "Ajouter";
            btnEx5AddClient.Click += ButtonEx5AddClient_Click;
            // 
            // btnEx5UpdateClient
            // 
            btnEx5UpdateClient.Location = new Point(544, 35);
            btnEx5UpdateClient.Name = "btnEx5UpdateClient";
            btnEx5UpdateClient.Size = new Size(60, 27);
            btnEx5UpdateClient.TabIndex = 7;
            btnEx5UpdateClient.Text = "Modifier";
            btnEx5UpdateClient.Click += ButtonEx5UpdateClient_Click;
            // 
            // btnEx5DeleteClient
            // 
            btnEx5DeleteClient.Location = new Point(612, 35);
            btnEx5DeleteClient.Name = "btnEx5DeleteClient";
            btnEx5DeleteClient.Size = new Size(60, 27);
            btnEx5DeleteClient.TabIndex = 8;
            btnEx5DeleteClient.Text = "Supprimer";
            btnEx5DeleteClient.Click += ButtonEx5DeleteClient_Click;
            // 
            // dgvEx5Clients
            // 
            dgvEx5Clients.AllowUserToAddRows = false;
            dgvEx5Clients.ColumnHeadersHeight = 29;
            dgvEx5Clients.Location = new Point(12, 70);
            dgvEx5Clients.Name = "dgvEx5Clients";
            dgvEx5Clients.RowHeadersWidth = 51;
            dgvEx5Clients.Size = new Size(760, 150);
            dgvEx5Clients.TabIndex = 9;
            dgvEx5Clients.SelectionChanged += DataGridViewEx5Clients_SelectionChanged;
            // 
            // lblEx5Commandes
            // 
            lblEx5Commandes.Location = new Point(12, 230);
            lblEx5Commandes.Name = "lblEx5Commandes";
            lblEx5Commandes.Size = new Size(100, 20);
            lblEx5Commandes.TabIndex = 10;
            lblEx5Commandes.Text = "Commandes:";
            // 
            // lblEx5Montant
            // 
            lblEx5Montant.Location = new Point(12, 253);
            lblEx5Montant.Name = "lblEx5Montant";
            lblEx5Montant.Size = new Size(60, 20);
            lblEx5Montant.TabIndex = 11;
            lblEx5Montant.Text = "Montant:";
            // 
            // txtEx5Montant
            // 
            txtEx5Montant.Location = new Point(80, 253);
            txtEx5Montant.Name = "txtEx5Montant";
            txtEx5Montant.Size = new Size(80, 27);
            txtEx5Montant.TabIndex = 12;
            // 
            // lblEx5DescriptionCommande
            // 
            lblEx5DescriptionCommande.Location = new Point(168, 253);
            lblEx5DescriptionCommande.Name = "lblEx5DescriptionCommande";
            lblEx5DescriptionCommande.Size = new Size(80, 20);
            lblEx5DescriptionCommande.TabIndex = 13;
            lblEx5DescriptionCommande.Text = "Description:";
            // 
            // txtEx5Description
            // 
            txtEx5Description.Location = new Point(258, 253);
            txtEx5Description.Name = "txtEx5Description";
            txtEx5Description.Size = new Size(150, 27);
            txtEx5Description.TabIndex = 14;
            // 
            // btnEx5AddCommande
            // 
            btnEx5AddCommande.Location = new Point(416, 253);
            btnEx5AddCommande.Name = "btnEx5AddCommande";
            btnEx5AddCommande.Size = new Size(60, 27);
            btnEx5AddCommande.TabIndex = 15;
            btnEx5AddCommande.Text = "Ajouter";
            btnEx5AddCommande.Click += ButtonEx5AddCommande_Click;
            // 
            // btnEx5UpdateCommande
            // 
            btnEx5UpdateCommande.Location = new Point(484, 253);
            btnEx5UpdateCommande.Name = "btnEx5UpdateCommande";
            btnEx5UpdateCommande.Size = new Size(60, 27);
            btnEx5UpdateCommande.TabIndex = 16;
            btnEx5UpdateCommande.Text = "Modifier";
            btnEx5UpdateCommande.Click += ButtonEx5UpdateCommande_Click;
            // 
            // btnEx5DeleteCommande
            // 
            btnEx5DeleteCommande.Location = new Point(552, 253);
            btnEx5DeleteCommande.Name = "btnEx5DeleteCommande";
            btnEx5DeleteCommande.Size = new Size(60, 27);
            btnEx5DeleteCommande.TabIndex = 17;
            btnEx5DeleteCommande.Text = "Supprimer";
            btnEx5DeleteCommande.Click += ButtonEx5DeleteCommande_Click;
            // 
            // dgvEx5Commandes
            // 
            dgvEx5Commandes.AllowUserToAddRows = false;
            dgvEx5Commandes.ColumnHeadersHeight = 29;
            dgvEx5Commandes.Location = new Point(12, 290);
            dgvEx5Commandes.Name = "dgvEx5Commandes";
            dgvEx5Commandes.RowHeadersWidth = 51;
            dgvEx5Commandes.Size = new Size(760, 135);
            dgvEx5Commandes.TabIndex = 18;
            // 
            // lblStatutEx5
            // 
            lblStatutEx5.Location = new Point(12, 435);
            lblStatutEx5.Name = "lblStatutEx5";
            lblStatutEx5.Size = new Size(760, 22);
            lblStatutEx5.TabIndex = 19;
            lblStatutEx5.Text = "Prêt";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 500);
            Controls.Add(tabControl);
            Name = "Form1";
            Text = "Exercices ADO.NET";
            tabControl.ResumeLayout(false);
            tabExercice1.ResumeLayout(false);
            tabExercice1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClients).EndInit();
            tabExercice2.ResumeLayout(false);
            tabExercice2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCommandes).EndInit();
            tabExercice3.ResumeLayout(false);
            tabExercice3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDataSet).EndInit();
            tabExercice4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCommandesDetail).EndInit();
            tabExercice5.ResumeLayout(false);
            tabExercice5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEx5Clients).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEx5Commandes).EndInit();
            ResumeLayout(false);
        }

        private TabControl tabControl;
        private TabPage tabExercice1;
        private Label lblDomaine;
        private TextBox? txtDomaine;
        private Button? btnRechercher;
        private DataGridView? dgvClients;

        private TabPage tabExercice2;
        private Label lblClientId;
        private TextBox? txtClientId;
        private Label lblMontant;
        private TextBox? txtMontant;
        private Label lblDescription;
        private TextBox? txtDescription;
        private Button? btnAjouterCommande;
        private Label? lblStatutTransaction;
        private DataGridView? dgvCommandes;

        private TabPage tabExercice3;
        private Label lblEx3Info;
        private Button? btnChargerDataSet;
        private Label lblClientIdEx3;
        private TextBox? txtClientIdEx3;
        private Label lblNouveauNom;
        private TextBox? txtNouveauNom;
        private Button? btnModifierClient;
        private Label lblNomNouveau;
        private TextBox? txtNomNouveau;
        private Label lblEmailNouveau;
        private TextBox? txtEmailNouveau;
        private Label lblSoldeNouveau;
        private TextBox? txtSoldeNouveau;
        private Button? btnAjouterClient;
        private DataGridView? dgvDataSet;
        private Button? btnSynchroniser;
        private Button? btnRafraichir;
        private Label? lblStatutDataSet;

        private TabPage tabExercice4;
        private Label lblEx4Info;
        private Button? btnChargerRelations;
        private TreeView? trvClients;
        private DataGridView? dgvCommandesDetail;
        private Label? lblStatutRelation;

        private TabPage tabExercice5;
        private Label lblEx5Clients;
        private TextBox? txtEx5Nom;
        private Label lblEx5Email;
        private TextBox? txtEx5Email;
        private Label lblEx5Solde;
        private TextBox? txtEx5Solde;
        private Button? btnEx5AddClient;
        private Button? btnEx5UpdateClient;
        private Button? btnEx5DeleteClient;
        private DataGridView? dgvEx5Clients;
        private Label lblEx5Commandes;
        private Label lblEx5Montant;
        private TextBox? txtEx5Montant;
        private Label lblEx5DescriptionCommande;
        private TextBox? txtEx5Description;
        private Button? btnEx5AddCommande;
        private Button? btnEx5UpdateCommande;
        private Button? btnEx5DeleteCommande;
        private DataGridView? dgvEx5Commandes;
        private Label? lblStatutEx5;
    }
}

