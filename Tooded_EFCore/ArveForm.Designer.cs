namespace Tooded_EFCore
{
    partial class ArveForm
    {
        private Label lblKokku;
        private System.Windows.Forms.ListBox listOstukorv;
        private System.Windows.Forms.Button btnLisaKorvi;
        private System.Windows.Forms.Button btnGenPDF;
        private System.Windows.Forms.Button btnSaadaEmail;

        private void InitializeComponent()
        {
            this.lblKokku = new Label();
            this.lblKokku.Name = "lblKokku";
            this.lblKokku.Text = "Kokku: 0 €";
            this.lblKokku.Location = new Point(20, 325);
            this.lblKokku.AutoSize = true;
            this.Controls.Add(this.lblKokku);


            listOstukorv = new ListBox();
            btnLisaKorvi = new Button();
            btnGenPDF = new Button();
            btnSaadaEmail = new Button();
            SuspendLayout();
            // 
            // listOstukorv
            // 
            listOstukorv.Location = new Point(20, 20);
            listOstukorv.Name = "listOstukorv";
            listOstukorv.Size = new Size(300, 289);
            listOstukorv.TabIndex = 0;
            // 
            // btnLisaKorvi
            // 
            btnLisaKorvi.Location = new Point(350, 20);
            btnLisaKorvi.Name = "btnLisaKorvi";
            btnLisaKorvi.Size = new Size(75, 23);
            btnLisaKorvi.TabIndex = 1;
            btnLisaKorvi.Text = "Lisa toode korvi";
            btnLisaKorvi.Click += btnLisaKorvi_Click;
            // 
            // btnGenPDF
            // 
            btnGenPDF.Location = new Point(350, 70);
            btnGenPDF.Name = "btnGenPDF";
            btnGenPDF.Size = new Size(75, 23);
            btnGenPDF.TabIndex = 2;
            btnGenPDF.Text = "Genereeri PDF";
            btnGenPDF.Click += btnGenPDF_Click;
            // 
            // btnSaadaEmail
            // 
            btnSaadaEmail.Location = new Point(350, 120);
            btnSaadaEmail.Name = "btnSaadaEmail";
            btnSaadaEmail.Size = new Size(75, 23);
            btnSaadaEmail.TabIndex = 3;
            btnSaadaEmail.Text = "Saada emailiga";
            btnSaadaEmail.Click += btnSaadaEmail_Click;
            // 
            // ArveForm
            // 
            ClientSize = new Size(550, 350);
            Controls.Add(listOstukorv);
            Controls.Add(btnLisaKorvi);
            Controls.Add(btnGenPDF);
            Controls.Add(btnSaadaEmail);
            Name = "ArveForm";
            Text = "Arve";
            Load += ArveForm_Load;
            ResumeLayout(false);
        }
    }
}