<script setup lang="ts">
import { ref, onMounted } from "vue";
import { toast } from 'vue3-toastify';
import 'vue3-toastify/dist/index.css';

type LegalContract = {
  id: string,
  author: string,
  legalEntity: string,
  contract: string,
};

let legalContract = ref({} as LegalContract);
const props = defineProps(['id']);

onMounted(() => {
  fetchData();
});

function fetchData(): void {

  fetch('legalcontracts/' + props.id, {
    method: 'GET',
    headers: {
      'Content-Type': 'application/json',
      'X-Content-Type-Options': 'nosniff',
    }})
      .then(r => r.json())
      .then(json => {
        legalContract.value = json as LegalContract;
        return;
      });
}

async function updateLegalContract(): Promise<void> {
  const response = await fetch('legalcontracts', {
    method: 'PUT',
    headers: {
      'Content-Type': 'application/json',
      'X-Content-Type-Options': 'nosniff',
    },
    body: JSON.stringify(legalContract.value),
  });
  if (response.ok) {
    toast('Legal Contract updated successfully', {
      type: 'success',
    });
  } else {
    toast('Failed to update Legal Contract', {
      type: 'error',
    });
  }
}
</script>

<template>
  <h3>Update Legal Contract</h3>
  <br />
  <form>
    <div class="form-row">
      <div class="form-group col-md-6">
        <label for="author">Author:</label>
        <input title="Author" type="text" class="form-control" name="author" id="author" v-model="legalContract.author">
      </div>
      <div class="form-group col-md-6">
        <label for="legalEntity">Legal Entity:</label>
        <input  type="text" id="legalEntity" name="legalEntity" v-model="legalContract.legalEntity" class="form-control">
      </div>
    </div>
    <div class="form-group">
      <label for="contract">Contract:</label>
      <textarea type="text" class="form-control" id="contract" v-model="legalContract.contract" rows="10"></textarea>
    </div>

    <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
      <div class="btn-group mr-2" role="group" aria-label="First group">
        <button type="submit" class="btn btn-success breathing-space" @click="updateLegalContract">Update Legal Contract</button>
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