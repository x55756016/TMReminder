using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RestHelperUI.chlidForm
{
    public partial class zjbForm : Form
    {
        private List<wuqingxi> wqxList = new List<wuqingxi>();
        private Form1 fatherForm;
        public zjbForm(Form1 form)
        {
            fatherForm = form;
            InitializeComponent();
            wuqingxi step1 = new wuqingxi();
            step1.stepName = @"第一步：小鸡啄米";
            step1.stepcontent = "抬头挺胸，坐直后用头开始写米字，持续一分钟";
            step1.stepTime = 60;
            wqxList.Add(step1);

            wuqingxi step2 = new wuqingxi();
            step2.stepName = @"第二步：小猫弓腰";
            step2.stepcontent = @"动作一：蹲下，手掌置于脚背上，手掌保持不动，腿直立弯曲。
动作二：保持腿直立，松开手掌，来回将手掌压至脚背，持续一分钟";
            step2.stepTime = 60;
            wqxList.Add(step2);


            wuqingxi step3= new wuqingxi();
            step3.stepName = @"第三步：大鹏展翅";
            step3.stepcontent = @"动作一：张开双手，向上合并至头顶，左右手指交叉手掌操天，双手用力往上提，来回几回合，持续一分钟";
            step3.stepTime = 60;
            wqxList.Add(step3);

            wuqingxi step4 = new wuqingxi();
            step4.stepName = @"第四步：猛虎回头";
            step4.stepcontent = @"动作一：站立，保持腿部不动，转动腰部尽量回头往后看，往左旋转腰部看两次，往右旋转腰部看两次，持续一分钟";
            step4.stepTime = 60;
            wqxList.Add(step4);

            wuqingxi step5 = new wuqingxi();
            step5.stepName = @"第五步：蛇行千里";
            step5.stepcontent = @"动作一：站立，保持腿部不动，腰往左右弯曲后复原，然后腰部往后弯曲后复原，持续一分钟";
            step5.stepTime = 60;
            wqxList.Add(step5);

            timer1.Start();
        }

        private int wqxIndex = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
             wuqingxi ent=wqxList[wqxIndex];
             ShowNextStep(ent);
            if(ent.stepTime-1<=0)
            {
                if(wqxIndex>=wqxList.Count-1)
                {
                    timer1.Stop();
                }
                wqxIndex++;
            }
        }

        private void ShowNextStep(wuqingxi ent)
        {
            ent.stepTime = ent.stepTime-1;
            labelName.Text = ent.stepName+" 剩余："+ent.stepTime+" 秒";
            txtcontext.Text = ent.stepcontent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.fatherForm.Show();
        }

        private void zjbForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }

    public class wuqingxi
    {
        public string stepName;
        public string stepcontent;
        public int stepTime;
    }
}
