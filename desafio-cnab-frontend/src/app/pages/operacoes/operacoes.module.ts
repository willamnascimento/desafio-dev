import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FileUploadService } from 'src/app/shared/services/file-upload.service';
import { OperacoesRoutingModule } from './operacoes-routing.module';
import { OperacoesComponent } from './operacoes.component';

@NgModule({
    imports: [
        CommonModule, 
        OperacoesRoutingModule],
    declarations: [
        OperacoesComponent],
    providers: [
        FileUploadService]
})
export class OperacoesModule {}
