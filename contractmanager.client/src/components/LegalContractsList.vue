<script lang="ts">
import { defineComponent } from 'vue';

type LegalContracts = {
    id: string,
    author: string,
    legalEntity: string,
    contract: string,
    createdAt: string,
    updatedAt: string
}[];

interface Data {
    loading: boolean,
    legalContracts: null | LegalContracts
}

export default defineComponent({
  data(): Data {
    return {
      loading: false,
      legalContracts: null,
    };
  },
  created() {
    // fetch the data when the view is created and the data is
    // already being observed
    this.fetchData();
  },
  watch: {
    // call again the method if the route changes
    '$route': 'fetchData',
  },
  methods: {
    fetchData(): void {
      this.legalContracts = null;
      this.loading = true;

      fetch('legalcontracts')
          .then(r => r.json())
          .then(json => {
            this.legalContracts = json as LegalContracts;
            this.loading = false;
            return;
          });
    },
  },
});
</script>

<template>
  <div>
    <h1>Legal Contracts</h1>
    <table>
      <thead>
        <tr>
          <th>Author</th>
          <th>Legal Entity</th>
          <th>Contract</th>
          <th>Created At</th>
          <th>Updated At</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="contract in legalContracts" :key="contract.id">
          <td>{{ contract.author }}</td>
          <td>{{ contract.legalEntity }}</td>
          <td>{{ contract.contract }}</td>
          <td>{{ contract.createdAt }}</td>
          <td>{{ contract.updatedAt }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<style scoped>
th {
  font-weight: bold;
}
tr:nth-child(even) {
  background: #F2F2F2;
}

tr:nth-child(odd) {
  background: #FFF;
}

th, td {
  padding-left: .5rem;
  padding-right: .5rem;
}

.weather-component {
  text-align: center;
}

table {
  margin-left: auto;
  margin-right: auto;
}
</style>