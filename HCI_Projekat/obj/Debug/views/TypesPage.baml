   M S B A M L   `   `   `  ����  HCI_Projekat"    HCI_Projekat.views.TypesPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      >d2http://schemas.microsoft.com/expression/blend/2008    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        N� 
Background
  ����� N� Title$ 	TypesPage��5	      .��5
      (� .��5   
   � $	��505��6   .+�5      �� -   5        $��	InfoPanel��5      $	��274��6&   $	��258��63   $��
0,0,42,207q�6?   $��Right=�6S   $��Bottom=�6o    � DataContext 6�   ��  �� ElementName$ dataGridType�� �� Path$ SelectedItem�.+�5      �� -   5        $
��opis��5      $��14(�6$   $��27��62   $��49��6>   $��Microsoft Sans Serif)�6I   $��18��6k   $��Right=�6y   $��Bottom=�6�    �� Left$ 5��6�   
 �� Top$	 110��6�   .��6�   Opis:6�   �� 5      -   5        $��textBox2��5   B   $��80��6   $
��Left=�6'   $	��Top=�6R   $	��120��6j   $	 130��6�   $	 115��6�   ��6v   �� *Description+ �� Mode$ TwoWay=�6�   �� 5      -   5        $	��ime��5      $��24��6$   $��44��60   $��14(�6;   $��Microsoft Sans Serif)�6I   $��18��6k   $ 5��6y   $ 80��6�   $��Right=�6�   $��Bottom=�6�   .��6�   Ime:6�   �� 5      -   5        $��textBox1��5   A   $��18��6   $
��Left=�6&   $	��Top=�6Q   $	��120��6i   $	 130��6�   $ 85��6�   ��6u   �� *Name+$ TwoWay=�6�   �� 5      -   5        $��id��5      $��24��6#   $��63��6/   $��14(�6:   $��Microsoft Sans Serif)�6H   $��18��6j   $ 50��6x   $ 5��6�   $��Right=�6�   $��Bottom=�6�   .��6�   	Oznaka:6�   �� 5      -   5        $��textBox3��5   B   $��18��6   $
��Left=�6'   $	��Top=�6R   $	��120��6j   $	 130��6�   $ 55��6�    �� 
IsReadOnly . ��6v   �� *Id+$ TwoWay=�6�   �� 5      -   5        $��label1��5      $��36��6&   $	��183��62   $��16(�6>   $��Microsoft Sans Serif)�6L   $��18��6n   $��Right=�6|   $��Bottom=�6�   $ 5��6�   $ 5��6�   .��6�   Opis selektovanog tipa6�   �� 5      -	   5        $��image2��5   @   $��32��6   $
��Left=�6$   $
��Fill=�6N   $	��Top=�6]   $��32��6u   $	 190��6�   $ 5��6�   ��6�   �� *
IconPath+6�   5      � 5      -
   5        	 �Name$	 tableGridType��5      
 � ColumnDefinitions
 5      �� 5      $
��197* �6'   �� 5      $
��299* �6'   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��dataGridType��5   M      AutoGenerateColumns .  $��25,35,25,210q�67   {�.    SelectionMode$ Single=�6�      CanUserSortColumns .    CanUserResizeColumns .     ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6�   $
��Auto=�6  ��6a   �� $ 	TypesList�$ OneWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Oznaka��6-      
IsReadOnly .    Width$ 50 6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *Id+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�     5      $ Naziv��6-    . $ 95 6�    6<   �� *Name+$ TwoWay=�$ PropertyChanged=�6�   5       5!      �� 5"      -   5        $��Dodaj��5"      $��2��6"   $��68,377,352,105q�6E   $��23��6]   $��76��6i   .��6t   Dodaj6{   �� 5#      -   5        $��Ukloni��5#      $��1��6#   $��68,310,352,170q�6F   $��23��6^   $��76��6j    J� RenderTransformOrigin$ 0.533,-0.565&�6u   .��6�   Ukloni6�   �� 5$      -   5        $��button4��5$   ?   $��Sačuvaj��6   $��68,443, 352,40q�6'   6N   5%      5&      5'      