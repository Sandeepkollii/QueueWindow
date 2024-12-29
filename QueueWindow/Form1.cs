
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QueueWindow
{
    public partial class QueueForm : Form
    {
        private Queue<string> queue;

        public QueueForm()
        {
            InitializeComponent();
            queue = new Queue<string>();
        }

        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnEnqueue = new System.Windows.Forms.Button();
            this.btnDequeue = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();

            
            this.Text = "COLLECTIONS-QUEUE";
            this.Size = new System.Drawing.Size(500, 400);

            
            this.listBox1.Location = new System.Drawing.Point(100, 50);
            this.listBox1.Size = new System.Drawing.Size(300, 200);
            this.listBox1.Name = "listBox1";

            
            this.label1.Text = "Enter items into Queue";
            this.label1.Location = new System.Drawing.Point(100, 260);
            this.label1.Size = new System.Drawing.Size(150, 20);

            
            this.txtInput.Location = new System.Drawing.Point(250, 260);
            this.txtInput.Size = new System.Drawing.Size(150, 20);

            
            this.btnEnqueue.Text = "ENQUEUE";
            this.btnEnqueue.Location = new System.Drawing.Point(60, 300);
            this.btnEnqueue.Size = new System.Drawing.Size(90, 30);
            this.btnEnqueue.Click += new EventHandler(btnEnqueue_Click);

            this.btnShow.Text = "SHOW";
            this.btnShow.Location = new System.Drawing.Point(160, 300);
            this.btnShow.Size = new System.Drawing.Size(90, 30);
            this.btnShow.Click += new EventHandler(btnShow_Click);

            this.btnDequeue.Text = "DEQUEUE";
            this.btnDequeue.Location = new System.Drawing.Point(260, 300);
            this.btnDequeue.Size = new System.Drawing.Size(90, 30);
            this.btnDequeue.Click += new EventHandler(btnDequeue_Click);

            this.btnClear.Text = "CLEAR";
            this.btnClear.Location = new System.Drawing.Point(360, 300);
            this.btnClear.Size = new System.Drawing.Size(90, 30);
            this.btnClear.Click += new EventHandler(btnClear_Click);

            
            this.Controls.AddRange(new Control[] {
                this.listBox1,
                this.txtInput,
                this.label1,
                this.btnEnqueue,
                this.btnShow,
                this.btnDequeue,
                this.btnClear
            });
        }

        private void btnEnqueue_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtInput.Text))
                {
                    MessageBox.Show("Please enter an item to enqueue.");
                    return;
                }

                queue.Enqueue(txtInput.Text);
                txtInput.Clear();
                UpdateListBox();
                MessageBox.Show("Item enqueued successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error enqueueing item: {ex.Message}");
            }
        }

        private void btnDequeue_Click(object sender, EventArgs e)
        {
            try
            {
                if (queue.Count == 0)
                {
                    MessageBox.Show("Queue is empty!");
                    return;
                }

                string dequeuedItem = queue.Dequeue();
                UpdateListBox();
                MessageBox.Show($"Dequeued item: {dequeuedItem}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error dequeuing item: {ex.Message}");
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            UpdateListBox();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            queue.Clear();
            UpdateListBox();
            MessageBox.Show("Queue cleared successfully!");
        }

        private void UpdateListBox()
        {
            listBox1.Items.Clear();
            foreach (string item in queue)
            {
                listBox1.Items.Add(item);
            }
        }

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnEnqueue;
        private System.Windows.Forms.Button btnDequeue;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label1;
    }
}

