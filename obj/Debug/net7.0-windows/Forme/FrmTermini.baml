   M S B A M L   `   `   `  ����K  GZubna ordinacija, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Zubna_ordinacija.FormeZubna_ordinacija.Forme  5   	   '    !Zubna_ordinacija.Forme.FrmTermini   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Zubna_ordinacija.Forme     5   	     � Title$  Dodaj/Izmeni termin��5   	   $	��225��6%   $	��300��62   .��5	      � 
�������.+�5
   
   �� $��Datum: ��6   $
��Left=�6#   $��	29,30,0,0q�6>   $	��Top=�6Q    J� RenderTransformOrigin$ -1.035,-0.927&�6i   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dpDatum��5      $
��Left=�6&   $��
135,30,0,0q�6A   $	��120��6U   $	��Top=�6a   �� 5   
   $��Vreme: ��6   $
��Left=�6#   $��	29,60,0,0q�6>   $	��Top=�6Q   $ -1.035,-0.927&�6i   �� 5   
   -   5         ��Name$ 
btnSacuvaj��5      $��Sacuvaj��6%   
�������
��� d �$
��Left=�6i   $��
30,163,0,0q�6�   $��75��6�   $	��Top=�6�   6�   �� 5   
   -   5        $ 	btnOtkazi��5      $��Otkazi��6$   
���z���
���  ��$
��Left=�6c   $��180,163,0,0q�6~   $��75��6�   $	��Top=�6�   6�   �� 5   
   -   5         ��Name$ txtVreme��5      $
��Left=�6$   $��
135,61,0,0q�6?    �� TextWrapping$
 Wrap=�6S   $�� ��6g   $	��Top=�6o   $��23��6�   $	��120��6�   �� 5   
   $��	Tretman: ��6   $
��Left=�6%   $��	29,91,0,0q�6@   $	��Top=�6S   $ -1.035,-0.927&�6k   �� 5   
   -   5         ��Name$ 	cbTretman��5      $
��Left=�6&   $��
135,92,0,0q�6A   $	��Top=�6U   $��23��6m   $	��120��6y    �� DisplayMemberPath$ vrstaTretmana��6�    �� SelectedValuePath$ 	tretmanID��6�   �� 5   
   $��
Pacijent: ��6   $
��Left=�6&   $��
29,121,0,0q�6A   $	��Top=�6U   $ -1.035,-0.927&�6m   �� 5   
   -   5        $ 
cbPacijent��5      $
��Left=�6'   $��135,122,0,0q�6B   $	��Top=�6W   $��23��6o   $	��120��6{   $ JMBGPacijenta��6�   $ 
pacijentID��6�   5      5      