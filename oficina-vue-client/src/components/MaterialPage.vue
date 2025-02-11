<template>
    <v-container>
      <h1 class="text-h4 mb-6">Gerenciamento de Materiais</h1>
  
      <!-- Botão para Adicionar Material -->
      <v-btn color="primary" @click="openForm" class="mb-6">
        Adicionar Material
      </v-btn>
  
      <!-- Grid de Materiais -->
      <v-data-table
        :headers="headers"
        :items="materials"
        :items-per-page="10"
        class="elevation-1"
      >
        <!-- Slot personalizado para a coluna de ações -->
        <template v-slot:[`item.actions`]="{ item }">
          <v-icon small class="mr-2" @click="editMaterial(item)">
            mdi-pencil
          </v-icon>
          <v-icon small @click="deleteMaterial(item.id)">
            mdi-delete
          </v-icon>
        </template>
      </v-data-table>
  
      <!-- Diálogo para Adicionar/Editar Material -->
      <v-dialog v-model="dialog" max-width="500">
        <MaterialForm
          :material="selectedMaterial"
          @save="handleSave"
          @close="dialog = false"
        />
      </v-dialog>
    </v-container>
  </template>

<script>
import axios from 'axios';
import MaterialForm from '@/components/MaterialForm.vue';

const API_URL = 'https://localhost:7270/api/material';

export default {
  components: {
    MaterialForm,
  },
  data() {
    return {
      materials: [], // Lista de materiais
      dialog: false, // Controla a exibição do diálogo
      selectedMaterial: null, // Material selecionado para edição
      headers: [
        { text: 'ID', value: 'id' },
        { text: 'Nome', value: 'name' },
        { text: 'Preço', value: 'price' },
        { text: 'Ações', value: 'actions', sortable: false },
      ],
    };
  },
  async created() {
    await this.fetchMaterials();
  },
  methods: {
    // Busca todos os materiais
    async fetchMaterials() {
      try {
        const response = await axios.get(API_URL);
        this.materials = response.data;
      } catch (error) {
        console.error('Erro ao buscar materiais:', error);
      }
    },

    // Abre o formulário para adicionar material
    openForm() {
      this.selectedMaterial = null;
      this.dialog = true;
    },

    // Abre o formulário para editar material
    editMaterial(material) {
      this.selectedMaterial = { ...material };
      this.dialog = true;
    },

    // Salva ou atualiza um material
    async handleSave(material) {
      if (material.id) {
        await axios.put(`${API_URL}/${material.id}`, material);
      } else {
        await axios.post(API_URL, material);
      }
      this.dialog = false;
      await this.fetchMaterials(); // Atualiza a lista
    },

    // Exclui um material
    async deleteMaterial(id) {
      if (confirm('Tem certeza que deseja excluir este material?')) {
        await axios.delete(`${API_URL}/${id}`);
        await this.fetchMaterials(); // Atualiza a lista
      }
    },
  },
};
</script>

<style scoped>
/* Estilos personalizados (opcional) */
</style>