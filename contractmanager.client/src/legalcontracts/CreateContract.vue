<script setup lang="ts">
import { ref } from "vue";
import { toast } from 'vue3-toastify';
import 'vue3-toastify/dist/index.css';

type LegalContract = {
  author: string,
  legalEntity: string,
  contract: string,
};

let legalContract = ref({} as LegalContract);

async function createLegalContract(): Promise<void> {
  const response = await fetch('legalcontracts', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
      'X-Content-Type-Options': 'nosniff',
    },
    body: JSON.stringify(legalContract.value),
  });
  if (response.ok) {
    toast('Legal Contract created successfully', {
      type: 'success',
    });
  } else {
    toast('Failed to create Legal Contract', {
      type: 'error',
    });
  }
}
</script>

<template>
  <h3>Create Legal Contract</h3>
  <br />
  <form>
    <div class="form-row">
      <div class="form-group col-md-6">
        <label for="author">Author:</label>
        <input type="text" class="form-control" name="author" v-model="legalContract.author" id="author" placeholder="Author name">
      </div>
      <div class="form-group col-md-6">
        <label for="legalEntity">Legal Entity:</label>
        <input  type="text" id="legalEntity" name="legalEntity" v-model="legalContract.legalEntity" class="form-control" placeholder="Legal Entity">
      </div>
    </div>
    <div class="form-group">
      <label for="contract">Contract:</label>
      <textarea type="text" class="form-control" id="contract" v-model="legalContract.contract" rows="10" placeholder="Enter your contract description"></textarea>
    </div>
    
    <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
      <div class="btn-group mr-2" role="group" aria-label="First group">
        <button type="submit" class="btn btn-success breathing-space" @click="createLegalContract">Create Legal Contract</button>
      </div>
      <div class="btn-group mr-2" role="group" aria-label="Second group">
        <button type="submit" class="btn btn-info breathing-space">
          <router-link to="/list" class="nav-link nav-link-button">Back to List</router-link>
        </button>
      </div>
    </div>
  </form>
</template>

<style scoped>
  .btn-toolbar {
    display: flex;
    justify-content: right;
    padding-right: 2em;
  }
  .nav-link-button {
    color: white;
  }
  .breathing-space {
    margin: 1em;
  }
</style>