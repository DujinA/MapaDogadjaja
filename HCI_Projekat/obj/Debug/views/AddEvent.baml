   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	    HCI_Projekat!   HCI_Projekat.views.AddEvent   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   >d2http://schemas.microsoft.com/expression/blend/2008    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	     � WindowStartupLocation$  CenterScreen=�5	   	    � 
ResizeMode$ NoResize=�5
   	    � Title$ Dodavanje novog dogadjaja��5   	   $	��702��6+   $	��600��68    � DataContext 5   	   �� .��5      �  J� 	AllowDrop . 
�������$	��600��6/   $��	0,0,-6,-1q�6;   .+�5   
   �� -   5        $��label1��5   #   $��	10,15,0,0q�6   $��Normal&�61   $��14(�6F    .  $	��Top=�6f   $��Normal"�6�   $��Normal$�6�   $��Oznaka:��6�   $
��Left=�6�   $��60��6�   $��27��6�   $	��Top=�6�   �� 5   
   -   5        $��textBox1��5   &   $��
130,20,0,0q�6   $
��Left=�66   $	��140��6Q   $��21��6]   $	��Top=�6i   ��6�   �� *Id+ �� Mode$ TwoWay=�.��6�    � ToolTip 5      �� 5      Polje za unos oznake.�� 5      Oznaka mora biti jedinstvena.�� 5      *(Oznaka se sastoji malih slova i brojeva.5      .��5      5      �� 5   
   -   5        $��label2��5   4   $��Naziv:��6   $��	10,45,0,0q�6!   $��12(�6B   $��27��6P   $	��Top=�6\   $
��Left=�6t   $��60��6�   �� 5   
   -   5        $��	eventName��5   &   $��
130,50,0,0q�6   $��20��67   $	��Top=�6C   $
��Left=�6[   $	��140��6v   ��6�   �� *Name+$ TwoWay=�.��6�    5      �� 5      !Polje za unos naziva dogadjaja.�� 5      ;9Za naziv dogadjaja je dozvoljena upotreba svih karaktera.5       .��5!      5"      �� 5#   
   -   5        $��textBox3��5#   N   $��75��6   $
��Left=�6   $��130,290,0,0q�69   $	��Top=�6^   $	��140��6v   $1 +Polje u koje se unosi kratak opis dogadjaja��6�   ��6�   �� *Description+$ TwoWay=�6�   �� 5$   
   -   5        $��label4��5$   2   $
��Tip:��6   $��	10,75,0,0q�6   $
��Left=�6@   $��60��6[   $��28��6f   $	��Top=�6r   �� 5%   
   -   5        $��textBox4��5%   '   $��
130,80,0,0q�6   $��23��67   $	��Top=�6C   $
��Left=�6[   $	��140��6v    �� DisplayMemberPath$
 Name��6�    �� SelectedValuePath$ Id��6�   $N HIzabrati željeni tip dogadjaja od ponuđenih tipova iz padajuće liste.��6.  ��6�   �� *Types+$ TwoWay=�	 �� SelectedValue	 6�   �� *Type+$ TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=�6.  �� 5&   
   -   5        $��label5��5&   :   $��Posećenost:��6   $��
10,105,0,0q�6&   $��28��6H   $	��Top=�6T   $
��Left=�6l   $	��104��6�   �� 5'   
   -	   5        $��	comboBox1��5'   (   $��130,110,0,0q�6   $
��Left=�69   $	��140��6T   $��23��6`   $	��Top=�6l   $V PIzabrati iz padajuće liste broj ljudi koji bi trebalo da prisustvuju dogadjaju.��6�    �� Text 6�   �� *
Attendance+$ TwoWay=���6�   �� *AttendanceList+6�   �� 5(   
   -
   5        $��label8��5(   V   $��Humanitaran:��6   $
��Left=�6'   $��
10,135,0,0q�6B   $��28��6d   $	��Top=�6p   $	��127��6�   	� 5)   
   -   5        $��radioButton5��5)   _   $��Da��6   $��16��6#   $
��Left=�6/   $��130,145,0,0q�6J   $	��Top=�6s    	� 	GroupName$ rezervacija��6�    d� 	IsChecked 6�   �� *HumanitarianEventTrue+$ TwoWay=�	� 5*   
   -   5        $��radioButton6��5*   _   $��Ne��6   $��16��6#   $
��Left=�6/   $��190,145,0,0q�6J   $	��Top=�6s   $ rezervacija��6�    6�   �� *HumanitarianEventFalse+$ TwoWay=��� 5+   
   -   5        $��label9��5+   f   $��Cena održavanja:��6   $��27��6+   $
��Left=�67   $��
10,165,0,0q�6R   $	��Top=�6t   �� 5,   
   -   5        $��textBox7��5,   3   $��23��6   $��130,170,0,0q�6   $	��Top=�6C   $
��Left=�6[   $	��140��6v   $4 .Cena održavanja dogadjaja je izražena u USD.��6�   ��6�   �� *Cost+$ TwoWay=�6�   �� 5-   
   -   5        $��label10��5-   B   $��Država:��6   $��27��6"   $��
10,195,0,0q�6.   $	��Top=�6Q   $
��Left=�6i   $��60��6�   �� 5.   
   -   5        $��textBox5��5.   3   $��23��6   $��130,200,0,0q�6   $	��Top=�6C   $
��Left=�6[   $	��140��6v   ��6�   �� *	Country+$ TwoWay=��� 5/   
   -   5        $��label13��5/   @   $��Grad:��6   $��27��6    $��
10,225,0,0q�6,   $	��Top=�6O   $
��Left=�6g   $��60��6�   �� 50   
   -   5        $��textBox2��50   3   $��23��6   $��130,230,0,0q�6   $	��Top=�6C   $
��Left=�6[   $	��140��6v   ��6�   �� *City+$ TwoWay=��� 51   
   -   5        $��label11��51   g   $��Datum održavanja:��6   $��27��6,   $
��Left=�68   $��
10,255,0,0q�6S   $	��Top=�6v   $	��117��6�   (  "System.Windows.Controls.DatePicker  52   
   -   5        $��
datePicker��52   <   $��25��6   $
��Left=�6!   $	��Top=�6N   $	��140��6f   $��130,260,0,0q�6�   
 �� Now   DisplayDateStart# Z 6�      CalenderControlTemplate   CalendarStyle# �   53         Text 52   r   �� $ TwoWay=� �� Path$
 Date�   SelectedDate 6�   �� *Now+54      �� 55   
   $��Opis:��6   $��27��6    $��
10,285,0,0q�6,   $��60��6@   $
��Left=�6K   $	��Top=�6f   �� 56   
   -   5        $��button1��56   2   $��OK��6   $��
436,0,0,85q�6   $��25��6A   $��Bottom=�6M   $
��Left=�6�   $��75��6�   �� 57   
   -   5        $��button2��57   S   $��Odustani��6   $
��Left=�6$   $��
317,0,0,85q�6?   $��75��6b   $��Bottom=�6�   $��23��6�   �� 58   
   -   5        $��label12��58   _   $��Ikonica:��6   $��27��6#   $
��Left=�6/   $��350,385,0,0q�6J   $	��Top=�6n   $��48��6�   �� 59   
   -   5        $��image1��59   L   $��32��6   $
��Left=�6   $��420,425,0,0q�67   $
��Fill=�6Z   $	��Top=�6i   $��32��6�   $ Ikonica dogadjaja.��6�   ��6�   �� *Icon+$ TwoWay=�6�   �� 5:   
   $��Trenutne etikete:��6   $��27��6,   $��98��68   $��
10,385,0,0q�6C   $
��Left=�6W   $	��Top=�6r   �� 5;   
   -   5        $��listBox��5;   r   $��130,380,0,0q�6   $��75��6'   $	��Top=�63   $
��Left=�6K   $	��140��6f    �� SelectionMode$ Multiple=�6�   $ Lista dostupnih etiketa.��6�   ��6�   �� *
LabelsList+$ TwoWay=�5<      �� 5?   
   -   5        $��Izaberi ikonicu��5?      $��23��6+   $	��Top=�67   $��420,387,0,0q�6O   $
��Left=�6d   $��90��6   6�   �� 5@   
   $	��USD��6   $��27��6   $��14(�6*   $
��Left=�69   $��270,165,0,0q�6T   $	��Top=�6i   $��47��6�   5A      5B      